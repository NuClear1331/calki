using System;
using System.Windows.Forms;
using AngouriMath;
using AngouriMath.Extensions;
using static AngouriMath.MathS;
using MathNet.Numerics;
using MathNet.Symbolics;
using ScottPlot;

namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        private ScottPlot.FormsPlot scottPlot;
        
        public Form1()
        {
            InitializeComponent();
            scottPlot = new ScottPlot.FormsPlot();
            scottPlot.Dock = DockStyle.Right;
            scottPlot.Width = 400;
            scottPlot.Height = 400;
            Controls.Add(scottPlot);

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            try
            {

                string functionExpression = functionTextBox.Text;


                SymbolicExpression function = SymbolicExpression.Parse(functionExpression);
                var variableValues = new Dictionary<string, FloatingPoint>
                {
                    { "x", 0.0 }
                };

                double lowerLimit = double.Parse(lowerBoundTextBox.Text);
                double upperLimit = double.Parse(textBox3.Text);

                double nki_n = double.Parse(textBox1.Text);

               
                double scaledLowerLimit = ScaleLimits(lowerLimit,lowerLimit,upperLimit);
                double scaledUpperLimit = ScaleLimits(upperLimit, lowerLimit, upperLimit);


                Func<double, double> functionDelegate = x =>
                {
                    variableValues["x"] = x;
                    return function.Evaluate(variableValues).RealValue;
                };


                double result = GaussLegendreIntegrationMethod(scaledLowerLimit, scaledUpperLimit, nki_n, functionDelegate);


                resultLabel.Text = $"Wynik: {result:F6}";
                PlotFunction(functionDelegate, lowerLimit, upperLimit);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst¹pi³ b³¹d: {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PlotFunction(Func<double, double> function, double lower, double upper)
        {

            var plt = scottPlot.Plot;
            plt.Clear();


            double[] xValues = ScottPlot.DataGen.Range(lower, upper, 0.01);
            double[] yValues = xValues.Select(function).ToArray();


            plt.PlotScatter(xValues, yValues, label: "Funkcja");


            plt.PlotVLine(lower, color: System.Drawing.Color.Red, lineStyle: LineStyle.Dash, label: "Granice");
            plt.PlotVLine(upper, color: System.Drawing.Color.Red, lineStyle: LineStyle.Dash);

            scottPlot.Refresh();

            plt.Legend();


            plt.Render();
        }
        static double ScaleLimits(double x, double a, double b)
        {
            return ((x - a) / (b - a)) * 2 - 1;
        }
        static double GaussLegendreIntegrationMethod(double a, double b, double numPoints, Func<double, double> function)
        {
        
            double[] weights = {
        0.017614007139152118311861962351852816362143544625,
        0.040601429800386941331039952274932109879272679893,
        0.062672048334109063569506535187041606351601848151,
        0.083276741576704748724758143222046206100285860983,
        0.101930119817240435036750135480349876166691126300,
        0.118194531961518417312377377711382287005041219333,
        0.131688638449176626898494499748163134916110511251,
        0.142096109318382051329298325067164933034515413392,
        0.149172986472603746787828737001969436692679111725,
        0.152753387130725850698084331955097593491948979328,
        0.152753387130725850698084331955097593491948979328,
        0.149172986472603746787828737001969436692679111725,
        0.142096109318382051329298325067164933034515413392,
        0.131688638449176626898494499748163134916110511251,
        0.118194531961518417312377377711382287005041219333,
        0.101930119817240435036750135480349876166691126300,
        0.083276741576704748724758143222046206100285860983,
        0.062672048334109063569506535187041606351601848151,
        0.040601429800386941331039952274932109879272679893,
        0.017614007139152118311861962351852816362143544625
    };

            double[] points = {
        -0.076526521133497333754640409398838211004517335119,
        -0.227785851141645078080496195368574624743088434007,
        -0.373706088715419560672548177024927237395746554092,
        -0.510867001950827098004364050955250998425002199164,
        -0.636053680726515025452836696226285936743389116804,
        -0.746331906460150792614305070355641590310730473069,
        -0.839116971822218823394529061701520685329629365065,
        -0.912234428251325905867752441203298113049781225802,
        -0.963971927277913791267666131197277221912060327199,
        -0.993128599185094924786122388471320278222647147818,
        0.993128599185094924786122388471320278222647147818,
        0.963971927277913791267666131197277221912060327199,
        0.912234428251325905867752441203298113049781225802,
        0.839116971822218823394529061701520685329629365065,
        0.746331906460150792614305070355641590310730473069,
        0.636053680726515025452836696226285936743389116804,
        0.510867001950827098004364050955250998425002199164,
        0.373706088715419560672548177024927237395746554092,
        0.227785851141645078080496195368574624743088434007,
        0.076526521133497333754640409398838211004517335119
    };
            double result = 0;

          
            for (int i = 0; i < numPoints; i++)
            {
                double x = 0.5 * ((b - a) * points[i] + (b + a));
                result += weights[i] * function(x);
            }


            result *= 0.5 * (b - a);

            return result;
        }



    }

}


