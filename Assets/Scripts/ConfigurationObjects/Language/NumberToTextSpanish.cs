using System.Collections.Generic;
using UnityEngine;

namespace ConfigurationObjects.Language
{
    [CreateAssetMenu]
    public class NumberToTextSpanish : NumberToTextConfiguration
    {
        private readonly Dictionary<int, string> _teens = new Dictionary<int, string>
        {
            {1, "once"},
            {2, "doce"},
            {3, "trece"},
            {4, "catorce"},
            {5, "quince"}
        };

        private readonly Dictionary<int, string> _tens = new Dictionary<int, string>
        {
            {1, "diez"},
            {2, "veinte"},
            {3, "treinta"},
            {4, "cuarenta"},
            {5, "cincuenta"},
            {6, "sesenta"},
            {7, "setenta"},
            {8, "ochenta"},
            {9, "noventa"}
        };

        private readonly Dictionary<int, string> _units = new Dictionary<int, string>
        {
            {1, "uno"},
            {2, "dos"},
            {3, "tres"},
            {4, "cuatro"},
            {5, "cinco"},
            {6, "seis"},
            {7, "siete"},
            {8, "ocho"},
            {9, "nueve"}
        };

        public override string GetTextFromNumber(int number)
        {
            string numberText = "";

            numberText += GetThousands(number);
            numberText += GetHundreds(number);
            numberText += GetTens(number);
            numberText += GetUnits(number);

            return numberText;
        }

        private string GetThousands(int number)
        {
            if (number < 1000)
            {
                return "";
            }

            if (number < 2000)
            {
                return "mil ";
            }

            int numberWithoutHundredsTensAndUnits = (int)(number / 1000.0f);

            return GetTextFromNumber(numberWithoutHundredsTensAndUnits) + "mil ";
        }

        private string GetHundreds(int number)
        {
            if (number < 100)
            {
                return "";
            }

            int onlyHundredNumber = GetPlace(number, 100);

            if (onlyHundredNumber == 0)
            {
                return "";
            }

            if (number == 100)
            {
                return "cien ";
            }

            switch (onlyHundredNumber)
            {
                case 1:
                    return "ciento ";
                case 5:
                    return "quinientos ";
                case 7:
                    return "setecientos ";
                case 9:
                    return "novecientos ";
                default:
                    return _units[onlyHundredNumber] + "cientos ";
            }
        }

        private string GetTens(int number)
        {
            if (number < 10)
            {
                return "";
            }

            int onlyTenNumber = GetPlace(number, 10);
            int onlyUnitNumber = GetPlace(number, 1);

            if (onlyTenNumber == 0)
            {
                return "";
            }

            if (onlyUnitNumber == 0)
            {
                return _tens[onlyTenNumber];
            }

            if (onlyTenNumber == 1 && onlyUnitNumber > 0 && onlyUnitNumber < 6)
            {
                return _teens[onlyTenNumber];
            }

            if (onlyTenNumber == 1 && onlyUnitNumber > 5 && onlyUnitNumber < 10)
            {
                return "dieci";
            }

            if (number > 20 && number < 30)
            {
                return "veinti";
            }

            return _tens[onlyTenNumber] + " y ";
        }

        private string GetUnits(int number)
        {
            int onlyTenNumber = GetPlace(number, 10);
            int onlyUnitNumber = GetPlace(number, 1);

            if (number == 0)
            {
                return "cero";
            }

            if (onlyUnitNumber == 0 || onlyTenNumber == 1 && onlyUnitNumber > 0 && onlyUnitNumber < 6)
            {
                return "";
            }

            return _units[onlyUnitNumber] + " ";
        }
    }
}