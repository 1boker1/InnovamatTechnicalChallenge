using System;
using System.Collections.Generic;
using UnityEngine;

namespace InnovamatTechnicalChallenge.ConfigurationObjects
{
    [CreateAssetMenu]
    public class NumberToTextSpanish : NumberToTextConfiguration
    {
        private Dictionary<int, string> units = new Dictionary<int, string>()
        {
             { 1, "uno" },
             { 2, "dos" },
             { 3, "tres" },
             { 4, "cuatro" },
             { 5, "cinco" },
             { 6, "seis" },
             { 7, "siete" },
             { 8, "ocho" },
             { 9, "nueve" }
        };
        private Dictionary<int, string> tens = new Dictionary<int, string>()
        {
             { 1, "diez" },
             { 2, "veinte" },
             { 3, "treinta" },
             { 4, "cuarenta" },
             { 5, "cincuenta" },
             { 6, "sesenta" },
             { 7, "setenta" },
             { 8, "ochenta" },
             { 9, "noventa" }
        };
        private Dictionary<int, string> teens = new Dictionary<int, string>()
        {
             { 1, "once" },
             { 2, "doce" },
             { 3, "trece" },
             { 4, "catorce" },
             { 5, "quince" }
        };

        public override string GetTextFromNumber(int number)
        {
            string l_NumberText = "";

            l_NumberText += GetThousands(number);
            l_NumberText += GetHundreds(number);
            l_NumberText += GetTens(number);
            l_NumberText += GetUnits(number);

            return l_NumberText;
        }

        private string GetThousands(int number)
        {
            if (number < 1000)
                return "";

            int numberWithoutHundredstensandUnits=(int)(number/1000.0f);

            return GetTextFromNumber(numberWithoutHundredstensandUnits)+ " mil ";
        }

        private string GetHundreds(int number)
        {
            if (number < 100)
                return "";

            int onlyHundredNumber = GetPlace(number, 100);

            if (number == 100)
            {
                return "cien ";
            }
            else if (onlyHundredNumber < 1)
            {
                return "ciento ";
            }
            else if (onlyHundredNumber == 5)
            {
                return "quinientos ";
            }
            else if (onlyHundredNumber == 7)
            {
                return "setecientos ";
            }
            else if (onlyHundredNumber == 9)
            {
                return "novecientos ";
            }
            else
            {
                return units[onlyHundredNumber] + "cientos ";
            }
        }

        private string GetTens(int number)
        {
            if (number < 10)
                return "";

            int onlyTenNumber = GetPlace(number, 10);
            int onlyUnitNumber = GetPlace(number, 1);

            if (onlyTenNumber == 0)
            {
                return "";
            }
            if (onlyUnitNumber == 0)
            {
                return tens[onlyTenNumber];
            }

            if (onlyTenNumber == 1 && (onlyUnitNumber > 0 && onlyUnitNumber < 6))
            {
                return teens[onlyTenNumber];
            }
            else if (onlyTenNumber == 1 && (onlyUnitNumber > 5 && onlyUnitNumber < 10))
            {
                return "dieci";
            }
            else if (number > 20 && number < 30)
            {
                return "veinti";
            }
            else
            {
                return tens[onlyTenNumber] + " y ";
            }
        }

        private string GetUnits(int number)
        {
            int onlyTenNumber = GetPlace(number, 10);
            int onlyUnitNumber = GetPlace(number, 1);

            if (number == 0)
            {
                return "cero";
            }
            if (onlyUnitNumber == 0 || onlyTenNumber > 10 && onlyTenNumber < 16)
            {
                return "";
            }
            else
            {
                return units[onlyUnitNumber];
            }
        }
    }
}