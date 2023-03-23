using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
    public class ReadNumber
    {
        private long number;
        private string[] NumberString = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín", "mười", "trăm", "ngàn", "triệu", "tỷ" };
        private string[] SubNumberString = new string[] { "mốt", "lăm", "lẻ", "mươi" };

        public ReadNumber()
        {
            number = 0;
        }

        public ReadNumber(long i)
        {
            number = i;
        }

        public long Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public string reader()
        {
            string numberString = number.ToString();
            string result = "";
            string sub = "";
            bool le = false;
            while (numberString.Length > 0)
            {
                string temp;
                if (numberString.Length > 3)
                {
                    int t = numberString.Length % 3;
                    if (t == 0) t = 3;
                    temp = numberString.Substring(0, t);
                    if (temp == "000") le = true;
                    int d = numberString.Length - 1;
                    d = d / 3;
                    d = d % 3;
                    switch (d)
                    {
                        case 0: sub = NumberString[14] + " "; break;
                        case 1: sub = NumberString[12] + " "; break;
                        case 2: sub = NumberString[13] + " "; break;
                    }
                    numberString = numberString.Substring(t, numberString.Length - t);
                }
                else
                {
                    temp = numberString;
                    numberString = "";
                    sub = "";
                }
                while (temp.Length > 0)
                {
                    if ((temp != "000") && (temp != "00") && (temp != "0"))
                    {
                        if (le) { result += "lẻ "; le = false; }
                        switch (temp[0])
                        {
                            case '0':
                                {
                                    if (temp.Length == 3)
                                    {
                                        result += NumberString[0] + " " + NumberString[11] + " ";
                                    }
                                    else if (temp.Length == 2)
                                    {
                                        result += SubNumberString[2] + " ";
                                    }
                                    else
                                    {
                                        result += NumberString[0] + " ";
                                    }
                                    break;
                                }
                            case '1':
                                {
                                    if (temp.Length == 3)
                                    {
                                        result += NumberString[1] + " " + NumberString[11] + " ";
                                    }
                                    else if (temp.Length == 2)
                                    {
                                        result += NumberString[10] + " ";
                                    }
                                    else
                                    {
                                        result += NumberString[1] + " ";
                                    }
                                    break;
                                }
                            case '2':
                                {
                                    result = Convert(temp, NumberString[2], result);
                                    break;
                                }
                            case '3':
                                {
                                    result = Convert(temp, NumberString[3], result);
                                    break;
                                }
                            case '4':
                                {
                                    result = Convert(temp, NumberString[4], result);
                                    break;
                                }
                            case '5':
                                {
                                    result = Convert(temp, NumberString[5], result);
                                    break;
                                }
                            case '6':
                                {
                                    result = Convert(temp, NumberString[6], result);
                                    break;
                                }
                            case '7':
                                {
                                    result = Convert(temp, NumberString[7], result);
                                    break;
                                }
                            case '8':
                                {
                                    result = Convert(temp, NumberString[8], result);
                                    break;
                                }
                            case '9':
                                {
                                    result = Convert(temp, NumberString[9], result);
                                    break;
                                }
                        }
                        temp = temp.Substring(1, temp.Length - 1);
                    }
                    else break;
                }
                result += sub;
            }
            result = result.Replace("mươi năm", "mươi lăm");
            result = result.Replace("mười năm", "mười lăm");
            result = result.Replace("tỷ triệu ngàn", "tỷ");
            result = result.Replace("tỷ triệu", "tỷ");
            result = result.Replace("triệu ngàn", "triệu");
            result = result.Replace("triệu không trăm", "triệu");
            result = result.Replace("lẻ không trăm", "lẻ");
            result = result.Replace("lẻ lẻ", "lẻ");
            result = result.Replace("mươi một", "mươi mốt");
            if (result.Trim().EndsWith("lẻ")) result = result.Substring(0, result.Length - 3);
            return result;
        }

        public string Convert(string s1, string s2, string result)
        {
            if (s1.Length == 3)
            {
                result += s2 + " " + NumberString[11] + " ";
            }
            else if (s1.Length == 2)
            {
                result += s2 + " " + SubNumberString[3] + " ";
            }
            else
            {
                result += s2 + " ";
            }
            return result;
        }

        public string reader(long i)
        {
            Number = i;
            return UppercaseFirst(reader().Trim() + " đồng.");
        }

        private static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}