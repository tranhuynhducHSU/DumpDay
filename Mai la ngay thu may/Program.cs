using System;
using System.Text;

namespace Mai_la_ngay_thu_may
{
    class Program
    {
        struct dateTime {
            public int day;
            public int mon;
            public int year;
        }
        static string[] Arr = { "thứ 3", "thứ 4", "thứ 5", "thứ 6", "thứ 7", "chủ nhật", "thứ 2" };
        static string[] Arr1 = { "thứ 3", "thứ 2", "chủ nhật", "thứ 7", "thứ 6", "thứ 5", "thứ 4" };
        static dateTime dateDef;



        static void Main(string[] args)
        {
            dateDef.day = 14;
            dateDef.mon = 5;
            dateDef.year = 2019;
            dateTime date = dateDef;
            Console.OutputEncoding = Encoding.UTF8;
            string str = "";
            do {

                for (; ; )
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Nhập ngày cần tìm thứ?");
                        Console.Write("Ngày : ");
                        date.day = int.Parse(Console.ReadLine());
                        Console.Write("Tháng: ");
                        date.mon = int.Parse(Console.ReadLine());
                        Console.Write("Năm  : ");
                        date.year = int.Parse(Console.ReadLine());
                        if (checkInput(date))
                            break;
                    }
                    catch {};
                }

                str = dateOfWeek(date);
                Console.Write("Đó là ngày " + str);
                Console.WriteLine();
                Console.ReadLine();
                Console.Write("\nCó tiếp tục tìm ngày khác k? (y/n): ");
                str = Console.ReadLine();
            } while (str == "y");



        }

        private static string dateOfWeek(dateTime date)
        {
            string str = "";
            int temp;
            bool ktNgay = DateThanDateDef(date);
            if (ktNgay == true)
            {
                temp = TinhNgayCachBiet(date, dateDef);
                temp = temp % 7;
                str = Arr[temp];
            }
            else
            {
                temp = TinhNgayCachBiet(dateDef, date);
                temp = temp % 7;
                str = Arr1[temp];
            }
            return str;
        } 
            private static bool checkInput(dateTime date)
        {
                if (date.day > maxOfMon(date) || date.day < 0)
                {
                    return false;
                }
                if (date.mon > 12 || date.mon < 1)
                {
                    return false;
                }
                if (date.year < 1)
                {
                    return false;
                }
                return true;
        }

        

        private static int maxOfMon(dateTime date)
        {
            if(date.mon==1 || date.mon == 3 || date.mon == 5 || date.mon == 7 || date.mon == 8 || date.mon == 10 || date.mon == 12)
            {
                return 31;
            }
            else
            {
                if (date.mon == 4 || date.mon == 6 || date.mon == 9 || date.mon == 11)
                {
                    return 30;
                }
                else
                {
                    if (isLeapYear(date))
                        return 29;
                    else
                        return 28;
                }
            }
        }
        private static int TinhNgayCachBiet(dateTime datee, dateTime date)
        {
            int soNgayCachBiet;
            if (date.year == datee.year)
            {
                return soNgayCachBiet = TinhNgayCachBietThang(datee, date);
            }
            else
                return soNgayCachBiet=TinhSoNgayCachBietNam(datee,date);
        }

        private static int TinhSoNgayCachBietNam(dateTime datee, dateTime date)
        {
            
            
            return (maxOfMon(date)-date.day) + monWith2Date(12,date.mon+1,date) + monWith2Date(datee.mon-1,1,datee)+datee.day + yearWith2Date(datee,date) ;
        }

        private static int TinhNgayCachBietThang(dateTime datee, dateTime date)
        {
            int temp = datee.mon - date.mon;
            if (temp == 0 && datee.year==date.year)
            {
                return datee.day - date.day;
            }
            else
            {
                return maxOfMon(date) - date.day + datee.day+monWith2Day(datee,date);
            }
        }
        private static int monWith2Day(dateTime datee,dateTime date)
        {
           
            int temp = datee.mon - date.mon;
            dateTime dayTemp=date;
            int numDay=0;
            if (temp == 1)
            {
                return 0;
            }
            else
            {
                for(int i=date.mon+1; i<datee.mon; i++)
                {
                    dayTemp.mon += 1;
                    numDay+= maxOfMon(dayTemp);
                }
                return numDay;
            }

        }
        private static int monWith2Date(int monn,int mon,dateTime date)
        {
            if (monn < mon)
                return 0;
            int result=0;
            
            date.mon = mon;
            for(int i = mon; i <= monn; i++)
            {
                result += maxOfMon(date);
                date.mon++;
            }
            return result;
        }
        private static int yearWith2Date(dateTime datee,dateTime date)
        {
            int temp = datee.year - date.year;
            int numDay = 0;
            if (temp == 1)
            {
                return 0;
            }
            else
            {
                for (int i = date.year + 1; i < datee.year; i++)
                {
                    if((i % 4 == 0 && i % 100 != 0) || i % 400 == 0)
                    {
                        numDay += 1;
                    }
                    numDay += 365;
                }
                return numDay;
            }
        }

        

        private static bool isLeapYear(dateTime date)
        {
            if ( (date.year % 4 == 0 && date.year % 100 != 0) || date.year % 400 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool DateThanDateDef(dateTime date)//ngày được nhập có lớn hơn ngày mặc định
        {
            if (date.year > dateDef.year)
            {
                return true;
            }
            else
            {
                if (date.year < dateDef.year)
                {
                    return false;
                }
                else
                {
                    if (date.mon > dateDef.mon)
                    {
                        return true;
                    }
                    else
                    {
                        if (date.mon < dateDef.mon)
                        {
                            return false;
                        }
                        else
                        {
                            if (date.day > dateDef.day)
                            {
                                return true;
                            }
                            
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
        }
        

    }
}
