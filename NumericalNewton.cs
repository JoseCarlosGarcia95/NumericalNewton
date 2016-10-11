using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalNewton
{
    public class NumericalNewton
    {
        #region Private variables

        /// <summary>
        /// The point where newton starts.
        /// </summary>
        private readonly double _startPoint;

        /// <summary>
        /// Convergence test
        /// </summary>
        private readonly double _tol;

        /// <summary>
        /// Max number of iterations.
        /// </summary>
        private readonly uint _maxIterations = 100;

        /// <summary>
        /// Function where the roots have to be found.
        /// </summary>
        private readonly Func<double, double> _function;

        /// <summary>
        /// Derivate of function.
        /// </summary>
        private readonly Func<double, double> _functionDerivative;

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize a new interface for solving equations.
        /// </summary>
        /// <param name="function">Search root in this function.</param>
        public NumericalNewton(Func<double, double> function)
            : this(function, 0, Math.Pow(10, -6))
        {
        }

        /// <summary>
        /// Initialize a new interface for solving equations.
        /// </summary>
        /// <param name="function">Search root in this function</param>
        /// <param name="startPoint">Starting point</param>
        public NumericalNewton(Func<double, double> function, double startPoint)
            : this(function, startPoint, Math.Pow(10, -6))
        {
        }

        /// <summary>
        /// Initialize a new interface for solving equations.
        /// </summary>
        /// <param name="function">Search root in this function</param>
        /// <param name="startPoint">Starting point</param>
        /// <param name="tol">Tolerancy</param>
        public NumericalNewton(Func<double, double> function, double startPoint, double tol)
        {
            _startPoint = startPoint;
            _tol = tol;
            _function = function;

            _functionDerivative = Derivative;
        }

        /// <summary>
        /// Initialize a new interface for solving equations. Using this method, the method will converge faster.
        /// </summary>
        /// <param name="function">Search root in this function</param>
        /// <param name="functionDerivative">The derivative function</param>
        /// <param name="startPoint">Starting point</param>
        /// <param name="tol">Tolerancy</param>
        public NumericalNewton(Func<double, double> function, Func<double, double> functionDerivative, double startPoint,
            double tol, Func<double, double> functionDerivative1)
        {
            _startPoint = startPoint;
            _tol = tol;
            _functionDerivative = functionDerivative1;
            _function = function;

            _functionDerivative = functionDerivative;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Get the root of the function.
        /// </summary>
        /// <returns>NaN if the method doesn't converge and the root if converge.</returns>
        public double GetRootAroundStartPoint()
        {
            double x1, x0;
            int k;

            x0 = _startPoint;
            x1 = x0 + _tol*2;

            for (k = 0; k < _maxIterations; k++)
            {

                if (Math.Abs(x1 - x0) <= _tol)
                {
                    return x1;
                }

                x0 = x1;
                x1 = x0 - _function(x0)/_functionDerivative(x0);
            }

            return Double.NaN;
        }

        #endregion

        #region Private method

        /// <summary>
        /// Numerical derivative of a function.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private double Derivative(double x)
        {
            return (_function(x + _tol) - _function(x))/_tol;
        }

        #endregion
    }
}
