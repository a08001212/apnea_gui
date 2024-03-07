﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using OpenCvSharp;
using OpenCvSharp.XImgProc;
using System.IO;

namespace apnea_gui
{
    class ApneaVideoProcess
    {
        private string video_path;
        private double fps;
        private int videoWidth, videoHeight;
        private List<double> rr_rate;
        private VideoCapture videoCapture;
        private CascadeClassifier detector;
        private Rect chest_area;
        private Mat<int> mask;
        private double mask_count;
        public ApneaVideoProcess(string video_path)
        {
            detector = new CascadeClassifier(@"..\..\haarcascades\haarcascade_frontalface_alt2.xml");
            this.video_path = video_path;
            try
            {
                videoCapture = new VideoCapture(video_path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            rr_rate = new List<double>();
            videoWidth = (int)videoCapture.Get(VideoCaptureProperties.FrameWidth);
            videoHeight = (int)videoCapture.Get(VideoCaptureProperties.FrameHeight);

            fps = videoCapture.Get(VideoCaptureProperties.Fps);
            get_breath_data();
            videoCapture.Release();
        }

        void set_video_path(string video_path)
        {
            this.video_path = video_path;
            get_breath_data();
        }

        public void draw_data(List<Double> arr)
        {
            
        }

        public void write_to_csv(string filePath)
        {
             string s = "";
             rr_rate.ForEach(val => s += val.ToString() + ",");
             var csv = new StringBuilder();
             File.WriteAllText(filePath, s);
        }

        public List<double> get_rr_rate()
        {
            return rr_rate;
        }
        private Rect find_face(Mat<int> frame)
        {

            var faces = detector.DetectMultiScale(frame, 1.1, 3);
            if (faces.Length == 0)
            {
                return new Rect(-1, -1, -1, -1);
            }
            int ans = 0, max_area = 0;
            for (int i = 0; i < faces.Length; ++i)
            {
                var area = faces[i].Height * faces[i].Width;
                if (area > max_area)
                {
                    ans = i;
                    max_area = area;
                }
            }
            return faces[ans];
        }

        private void get_chest_area(Mat<int> frame)
        {
            Rect face = find_face(frame);
            if (face.X == -1)
            {
                chest_area = face;
                return;
            }

            int start_x = Math.Max((int)(face.X - face.Width), 0);
            int start_y = Math.Min(videoHeight - 1, (int)(face.Y + 1.25 * face.Height));
            int end_x = Math.Min(videoWidth - 1, (int)(face.Width * 3 + start_x)) - start_x;
            int end_y = Math.Min(videoHeight - 1, (int)(face.Height * 1.25 + start_y)) - start_y;
            chest_area = new Rect(start_x, start_y, end_x, end_y);
        }

        private Mat<int> get_chest_img(Mat<int> frame)
        {
            if (chest_area.X == -1)
            {
                return new Mat<int>(0, 0);
            }
            return new Mat<int>(frame, chest_area);
        }
        private void get_breath_data()
        {
            rr_rate.Clear();
            double last_data = 0.0;
            Mat<int> frame = new Mat<int>(videoHeight, videoWidth);
            bool first_frame = true;
            double rr_rate_sum = .0;
            while (videoCapture.Read(frame))
            {
                Cv2.CvtColor(frame, frame, ColorConversionCodes.RGB2GRAY);
                if (first_frame)
                {
                    get_chest_area(frame);
                    // can't find chest
                    if (chest_area.X == -1)
                        continue;
                    Mat<int> first_chest_img = get_chest_img(frame);
                    var super_pixel = SuperpixelSLIC.Create(first_chest_img, SLICType.SLICO, 150, 0.075F);
                    super_pixel.Iterate(10);
                    mask = new Mat<int>(first_chest_img.Height, first_chest_img.Width);
                    Mat<int> labels = new Mat<int>(super_pixel.GetNumberOfSuperpixels(), super_pixel.GetNumberOfSuperpixels());
                    super_pixel.EnforceLabelConnectivity(100);
                    super_pixel.GetLabelContourMask(mask);
                    super_pixel.GetLabels(labels);
                    mask_count = Cv2.Sum(mask)[0];

                    first_frame = false;
                }
                double frame_gray_value;
                Mat<int> chest_img = get_chest_img(frame);

                // can't find chest
                if (chest_img.Height == 0)
                {
                    rr_rate.Add(last_data);
                    continue;
                }
                Cv2.BitwiseAnd(chest_img, mask, chest_img);
                var img_sum = Cv2.Sum(chest_img);
                // show chest 
                // Cv2.ImShow("test", chest_img);
                // Cv2.WaitKey(1);
                double ans = (double)img_sum[0] / mask_count;
                rr_rate.Add(ans);
                rr_rate_sum += ans;
            }

            double rr_rate_average = rr_rate_sum / rr_rate.Count;
            for (int i = 0; i < rr_rate.Count; ++i)
            {
                rr_rate[i] -= rr_rate_average;
            }

        }
        public double get_fps()
        {
            return fps;
        }

    }
}
