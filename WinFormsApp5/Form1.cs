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

                
                Func<double, double> functionDelegate = x =>
                {
                    variableValues["x"] = x;
                    return function.Evaluate(variableValues).RealValue;
                };

                
                double lowerLimit = -1;
                double upperLimit = 1;

               
                double result = Integrate.OnClosedInterval(functionDelegate, lowerLimit, upperLimit, 5);

              
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

    }


    
}


