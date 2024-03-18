public class MyIirFilter
{
    private double[] a;
    private double[] b;
    private double[] bufferX;
    private double[] bufferY;

    public MyIirFilter()
    {
        // Coefficients for the Butterworth Bandpass filter
        // Replace these with your own coefficients
        a = new double[] { 1.0, -1.04298, 0.8128 };
        b = new double[] { 0.2062, 0, -0.2062 };
        bufferX = new double[a.Length];
        bufferY = new double[b.Length];
    }

    public double Filter(double input)
    {
        // Shift the values in the X buffer
        for (int i = bufferX.Length - 1; i > 0; i--)
        {
            bufferX[i] = bufferX[i - 1];
        }
        bufferX[0] = input;

        // Compute the output
        double output = 0;
        for (int i = 0; i < a.Length; i++)
        {
            output += a[i] * bufferX[i];
        }
        for (int i = 1; i < b.Length; i++)
        {
            output -= b[i] * bufferY[i];
        }

        // Shift the values in the Y buffer
        for (int i = bufferY.Length - 1; i > 0; i--)
        {
            bufferY[i] = bufferY[i - 1];
        }
        bufferY[0] = output;

        return output;
    }
}