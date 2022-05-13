namespace MVCBasics.Models
{
    public class DoctorModel
    {
        public static string WriteMessage()
        {
            return "Please enter your temperature:";
        }
        
        public static string CheckTemp(int temperature)
        {

            if (temperature >= 38)
                return "You have a fever!";
            else if (temperature < 35 && temperature > 0)
                return "You have hypothermia!";
            else if (temperature == 0)
                return "";
            else
                return "You do not have a fever.";
        }
    }
}
