using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCloudService.Models
{
    public enum InstanceSizes
    {
        [Display(Name = "Very Small")]
        verySmall,
        [Display(Name = "Small")]
        small,
        [Display(Name = "Medium")]
        medium,
        [Display(Name = "Large")]
        large,
        [Display(Name = "Very Large")]
        veryLarge,
        [Display(Name = "A6")]
        a6,
        [Display(Name = "A7")]
        a7,
    }

    public struct Prices
    {
        public const double VerySmall = 0.02;
        public const double Small = 0.08;
        public const double Medium = 0.16;
        public const double Large = 0.32;
        public const double VeryLarge = 0.64;
        public const double A6 = 0.90;
        public const double A7 = 1.80;
    }

    public class AzureCloudServiceCost
    {
        // Number of instances for a service
        [Required(ErrorMessage = "Required field")]
        [Range(2, Int32.MaxValue, ErrorMessage = "At least 2 instances required")]
        [Display(Name = "Number of Instances")]
        public int NoInstances { get; set; }

        // Size of an instance e.g. very small, small, etc
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Instance Size")]
        public InstanceSizes InstanceSize { get; set; }

        // Get the cost of a service based on number of instances and size for a year
        public double Cost
        {
            get
                {
                double hourlyPrice = 0;
                
                
                if (InstanceSize == InstanceSizes.verySmall)
                {
                    hourlyPrice = NoInstances * Prices.VerySmall;                   
                }
                else if (InstanceSize == InstanceSizes.small)
                {
                    hourlyPrice = NoInstances * Prices.Small;                    
                }
                else if (InstanceSize == InstanceSizes.medium)
                {
                    hourlyPrice = NoInstances * Prices.Medium;                    
                }
                else if (InstanceSize == InstanceSizes.large)
                {
                    hourlyPrice = NoInstances * Prices.Large;                    
                }
                else if (InstanceSize == InstanceSizes.veryLarge)
                {
                    hourlyPrice = NoInstances * Prices.VeryLarge;                    
                }
                else if (InstanceSize == InstanceSizes.a6)
                {
                    hourlyPrice = NoInstances * Prices.A6;                   
                }
                else if (InstanceSize == InstanceSizes.a7)
                {
                    hourlyPrice = NoInstances * Prices.A7;          
                }
                
                double dailyPrice = hourlyPrice * 24;
                double yearlyPrice;

                if (DateTime.IsLeapYear(DateTime.Now.Year))
                {
                    yearlyPrice = dailyPrice * 366;
                }
                else
                {
                    yearlyPrice = dailyPrice * 365;
                }
                return yearlyPrice;
            }
        }
    }
}
