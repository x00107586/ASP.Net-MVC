using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageCalc.Models
{
    public enum RedundancyDescriptions
    {
        Geographical, Local
    }

    // An Azure storage account
    public class AzureStorage
    {
        const double GeoCostPerGBLevel1 = 0.125;
        const double GeoCostPerGBLevel2 = 0.11;
        const double LocalCostPerGBLevel1 = 0.093;
        const double LocalCostPerGBLevel2 = 0.083;

        // GB Storage
        [Required(ErrorMessage = "Required field")]
        //[Range(1, Double.MaxValue, ErrorMessage = "Must be > 0")]
        [Display(Name = "Average GB usage per month")]
        public Double Storage { get; set; }

        // Redundancy type
        [Required(ErrorMessage = "Required field")]
        public RedundancyDescriptions Redundancy { get; set; }

        public double Cost
        {
            get
            {
                double cost = 0;
                if(Redundancy == RedundancyDescriptions.Geographical)
                {
                    if(Storage > 1000)
                    {
                        cost = ((1000 * GeoCostPerGBLevel1) + ((Storage-1000) * GeoCostPerGBLevel2));
                    }
                    else
                    {
                        cost = Storage * GeoCostPerGBLevel1;
                    }
                }
                else if (Redundancy == RedundancyDescriptions.Local)
                {
                    if (Storage > 1000)
                    {
                        cost = ((1000 * LocalCostPerGBLevel1) + ((Storage - 1000) * LocalCostPerGBLevel2));
                    }
                    else
                    {
                        cost = Storage * LocalCostPerGBLevel1;
                    }
                }
                return cost;
            }           
        }
    }
}
