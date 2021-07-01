using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClientSI.Requests
{
    public class IdentificationRequest
    {

        /// <summary>
        /// id of the project to call
        /// </summary>
        [Required]
        public string[] ProjectIds { get; set; }
        /// <summary>
        /// Name of the istance
        /// </summary>
        [Required]
        public string InstanceName { get; set; }
        /// <summary>
        /// points x coordinates
        /// </summary>
        [Required]
        public double[] X { get; set; }
        /// <summary>
        /// points y coordinates
        /// </summary>
        [Required]
        public double[] Y { get; set; }
        /// <summary>
        /// points Z coordinates
        /// </summary>
        [Required]
        public double[] Z { get; set; }
        /// <summary>
        /// Unit of measure project
        /// </summary>
        [Required]
        public string UnitOfMeasure { get; set; }

      


        public IdentificationRequest(string istanceName, string[] projectIds, double[] x, double[] y, double[] z, string unitOfMeasure)
        {
            this.ProjectIds = projectIds;
            InstanceName = istanceName;
            X = x;
            Y = y;
            Z = z;
            UnitOfMeasure = unitOfMeasure;
        }
    }
}
