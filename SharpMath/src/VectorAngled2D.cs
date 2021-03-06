﻿using System.Drawing;
using System.Diagnostics;

namespace Tools.Math.Geometry
{
    /// <summary>
    /// Represents a vector with a direction (angle). 
    /// </summary>
    /// <remarks>
    /// Author: 
    /// Version: 1.0.0.0
    /// Date: 
    /// </remarks>
    [DebuggerDisplay("X: {X}, Y: {Y}, dRotation: {dRotation}")]
    public class VectorAngled2D
    {
        /*****************************************************************/
        // Declarations
        /*****************************************************************/
        #region Declarations

        /// <summary>
        /// Getter for the X component of the vector. 
        /// </summary>
        public double X
        {
            get { return this._vect.X; }
            private set { }
        }

        /// <summary>
        /// Getter for the Y component of the vector. 
        /// </summary>
        public double Y
        {
            get { return this._vect.Y; }
            private set { }
        }

        /// <summary>
        /// Getter and Setter for the length of the vector. 
        /// </summary>
        public double dLength
        {
            get { return this._vectDefault.X; }
            set { this._vectDefault.X = value; }
        }

        private double _dRotation;
        /// <summary>
        /// Current rotational angle of the vector. 
        /// </summary>
        public double dRotation
        {
            get { return this._dRotation; }
            set
            {
                this._dRotation = SharpMath.GetAngleClamped(value);

                if (this._dRotation > this.dMaximum)
                    this._dRotation = this.dMaximum;
                else if (this._dRotation < this.dMinimum)
                    this._dRotation = this.dMinimum;

                this._vect = this._vectDefault.GetRotated(-this._dRotation); // Negative rotation -> clockwise rotation. 
            }
        }

        private double _dMinimum;
        /// <summary>
        /// Minimum allowed angle. 
        /// </summary>
        public double dMinimum
        {
            get { return this._dMinimum; }
            set { this._dMinimum = SharpMath.GetAngleClamped(value); }
        }

        private double _dMaximum;
        /// <summary>
        /// Maximum allowed angle. 
        /// </summary>
        public double dMaximum
        {
            get { return this._dMaximum; }
            set { this._dMaximum = SharpMath.GetAngleClamped(value); }
        }

        /// <summary>
        /// A default orientation vector. 
        /// </summary>
        private Vector2D _vectDefault;

        /// <summary>
        /// Underlying, rotated vector. 
        /// </summary>
        private Vector2D _vect;

        /// <summary>
        /// Point of origin in world space. 
        /// </summary>
        public PointF pntOrigin;

        #endregion Declarations
        /*****************************************************************/
        // Constructors
        /*****************************************************************/
        #region Constructors

        /// <summary>
        /// Creates a new angled vector, with the given values. 
        /// </summary>
        /// <param name="dLength">Length of the vector. </param>
        /// <param name="dMinimum">Minimum allowed angle for the vector. </param>
        /// <param name="dMaximum">Maximum allowed angle for the vector. </param>
        /// <param name="pntOrigin">Point of origin in world space. </param>
        public VectorAngled2D(double dMinimum, double dMaximum, double dLength, PointF pntOrigin)
        {
            this.dMinimum = dMinimum;
            this.dMaximum = dMaximum;
            this._vect = new Vector2D(dLength, 0);
            this._vectDefault = new Vector2D(dLength, 0);
            this.pntOrigin = pntOrigin; 
        }

        /// <summary>
        /// Creates a new angled vector, with default values. 
        /// </summary>
        public VectorAngled2D()
            : this(0, SharpMath.DEG_CIRCLE, 1, new PointF())
        {
        }

        /// <summary>
        /// Creates a new angled vector, at the given angle, with the given allowed range. 
        /// Ex.: At angle 90, with a range of 90, the minimum allowed angle will be 45, the maximum allowed angle 135. 
        /// </summary>
        /// <param name="dAngle">A starting angle for the vector. </param>
        /// <param name="dRange">A degrees range the vector is allowed to rotate, from its starting angle. </param>
        public VectorAngled2D(double dAngle, double dRange)
        {
            this._vect = new Vector2D(1, 0);
            this._vectDefault = new Vector2D(1, 0);

            double dMinimum = dAngle - (dRange / 2);
            double dMaximum = dAngle + (dRange / 2);

            //if (dMinimum < 0)
                dMinimum = 0;

            //if (dMaximum > csMaths.DEG_CIRCLE)
                dMaximum = SharpMath.DEG_CIRCLE;

            this.dMinimum = SharpMath.GetAngleClamped(dMinimum);
            this.dMaximum = SharpMath.GetAngleClamped(dMaximum);
            this.dRotation = dAngle;
        }

        /// <summary>
        /// Creates a new angled vector, with the given values. 
        /// </summary>
        /// <param name="dLength"></param>
        /// <param name="pntOrigin"></param>
        public VectorAngled2D(double dLength, PointF pntOrigin)
            : this(0, SharpMath.DEG_CIRCLE, dLength, pntOrigin)
        {
        }

        #endregion Constructors
        /*****************************************************************/
        // Methods
        /*****************************************************************/
        #region Methods

        /// <summary>
        /// Returns a new Vector2D, based on this angled vector. 
        /// </summary>
        /// <returns></returns>
        public Vector2D ToVector2D()
        {
            return new Vector2D(this.X, this.Y);
        }

        #endregion Methods
        /*****************************************************************/
        // Events
        /*****************************************************************/
        #region Events

        #endregion Events
    }
}
