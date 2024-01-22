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
                // Get the function expression from the TextBox
                string functionExpression = functionTextBox.Text;

                // Parse the function expression into a symbolic expression
                SymbolicExpression function = SymbolicExpression.Parse(functionExpression);
                var variableValues = new Dictionary<string, FloatingPoint>
                {
                    { "x", 0.0 } // Set the initial value for "x", you can change this as needed
                };

                // Convert the symbolic expression to a delegate
                Func<double, double> functionDelegate = x =>
                {
                    variableValues["x"] = x;
                    return function.Evaluate(variableValues).RealValue;
                };

                // Set the integration limits
                double lowerLimit = -1;
                double upperLimit = 1;

                // Calculate the integral using Gauss-Legendre method
                double result = Integrate.OnClosedInterval(functionDelegate, lowerLimit, upperLimit, 5);

                // Display the result
                resultLabel.Text = $"Result: {result:F6}";
                PlotFunction(functionDelegate, lowerLimit, upperLimit);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PlotFunction(Func<double, double> function, double lower, double upper)
        {
            // Plot the function using ScottPlot
            var plt = scottPlot.Plot; 
            plt.Clear();

            // Generate points for plotting
            double[] xValues = ScottPlot.DataGen.Range(lower, upper, 0.01);
            double[] yValues = xValues.Select(function).ToArray();

            // Plot the function
            plt.PlotScatter(xValues, yValues, label: "Function");

            // Highlight the integration area
            plt.PlotVLine(lower, color: System.Drawing.Color.Red, lineStyle: LineStyle.Dash, label: "Integration Limits");
            plt.PlotVLine(upper, color: System.Drawing.Color.Red, lineStyle: LineStyle.Dash);

            scottPlot.Refresh();
            // Show the legend
            plt.Legend();

            // Render the plot
            plt.Render();
        }

    }


    
}


