namespace StoreAppLibrary.Logic {
    public class Global {
        public static void UserStringToInt(string? Choose, string Question, string ResponseText, int IntoNumber) {
            // string? 
             while (Choose == null || Choose.Length <= 0 )
            {
                Thread.Sleep(3000);
                Console.Write(Question);
                Choose = Console.ReadLine();
                bool validchoice = int.TryParse(Choose, out IntoNumber);
                if (!validchoice || (IntoNumber > 4 && IntoNumber < 0) )
                {
                    Console.WriteLine(ResponseText);
                    Console.WriteLine();
                    Choose=null;
                    continue;
                }
            }
        }
    }
}