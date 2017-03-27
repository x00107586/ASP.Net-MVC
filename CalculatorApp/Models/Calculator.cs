using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Models
{
    public enum Operators
    {
        [Display(Name = " + ")]
        add,
        [Display(Name = " - ")]
        subtract,
        [Display(Name = " * ")]
        multiply,
        [Display(Name = " / ")]
        divide,
    }

    public class Calculator
    {
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Number A")]
        public double NumA { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Number B")]
        public double NumB { get; set; }

        [Display(Name = "Operator")]
        public Operators Operator { get; set; }

        public double Result { get; set; }

        public double Answer()
        {
            
                double answer = 0;
                if(Operator.ToString() == "add")
                {
                    answer = NumA + NumB;
                }
                else if(Operator.ToString() == "subtract")
                {
                    answer = NumA - NumB;
                }
                else if (Operator.ToString() == "multiply")
                {
                    answer = NumA * NumB;
                }
                else if (Operator.ToString() == "divide")
                {
                    answer = NumA / NumB;
                }
                return answer;
           
                
        } 
    }
}
