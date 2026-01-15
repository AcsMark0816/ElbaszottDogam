using System.Reflection.Metadata;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<AirPlanes> airPlanes = new List<AirPlanes>();
            airPlanes.Add(new AirPlanes("Igen",30,100,15,500,20,3));
            airPlanes.Add(new AirPlanes("Nem", 35, 105, 20, 500, 20, 3));
            airPlanes.Add(new AirPlanes("Talan", 40,110, 25, 500, 20, 1));
            airPlanes.Add(new AirPlanes("Lehet", 45, 115, 30, 500, 25, 3));
            airPlanes.Add(new AirPlanes("Majdnem", 50, 120, 35, 500, 20, 3));

            for (int i = 0; i < airPlanes.Count; i++) 
            {
                AirPlanes airPlane = airPlanes[i];
                Console.WriteLine(airPlane.ToString());
            
            }


            int Leggyorsabb = airPlanes[0].AvgSpeed;
            for (int i = 1; i < airPlanes.Count; i++)
            {
                if (airPlanes[i].AvgSpeed > Leggyorsabb)
                {
                    Leggyorsabb = airPlanes[i].AvgSpeed;
                }
                
            
            }
            Console.WriteLine(Leggyorsabb);

            int LegkevesebbIfo = airPlanes[0].Hours;
            for (int i = 1; i < airPlanes.Count; i++) {

                if (airPlanes[i].Hours < LegkevesebbIfo) { 
                
                            LegkevesebbIfo = airPlanes[i].Hours;                
                
                }
            
            
            }
            Console.WriteLine(LegkevesebbIfo);


            double osszes = 0;
            for (int i = 1; i < airPlanes.Count; i++) {
                osszes += airPlanes[i].FuelTankSize;
            
            }
            Console.WriteLine(osszes/airPlanes.Count);

            double legtobb = airPlanes[0].MaxRoute();
            for (int i = 1; i < airPlanes.Count; i++) {

                if (legtobb < airPlanes[i].MaxRoute()) {
                    legtobb = airPlanes[i].MaxRoute();
                }


            }

            Console.WriteLine(legtobb);


            Console.WriteLine(airPlanes[4].Flight(3000, 2));

            int OsszSpeed = 0;
            List<AirPlanes> Atlagplussz = new List<AirPlanes>();


            for (int i = 0; i < airPlanes.Count; i++) {

                OsszSpeed += airPlanes[i].AvgSpeed;
                
            }
            int valami = OsszSpeed / airPlanes.Count;
            Console.WriteLine(valami);


            for (int i = 0; i < airPlanes.Count; i++)
            {
                if (valami < airPlanes[i].AvgSpeed)
                {

                    Atlagplussz.Add(airPlanes[i]);
                }








            }

            for (int i = 0; i < Atlagplussz.Count; i++) {
            
            AirPlanes atlagok = Atlagplussz[i];
                Console.WriteLine(atlagok.ToString());
            
            }
        }
            




       public class AirPlanes
        {
            public string model {  get; set; }
            public int power {  get; set; }
            public double WeightCapacity { get; set; }
            public double FuelPerHour { get; set; }
            public double FuelTankSize { get; set; }
            public int AvgSpeed { get; set; }
            public int Hours { get ; set; }


            public AirPlanes(string model, int power, double WeightCapacity, double FuelPerHour, double FuelTankSize, int AvgSpeed, int Hours)
            {
                this.model = model;
                this.power = power;
                this.WeightCapacity = WeightCapacity;
                this.FuelPerHour = FuelPerHour;
                this.FuelTankSize = FuelTankSize;
                this.AvgSpeed = AvgSpeed;
                this.Hours = Hours;
            }

            public int MaxRoute()
            {
                double Hasznalhato = FuelTankSize * 0.9;
                double MaxIdo = Hasznalhato / FuelPerHour;
                double MaxTav = MaxIdo * AvgSpeed;

                return (int)MaxTav;
            }

            public string Flight(int lenght,int weight)
            {
                if (weight > WeightCapacity)
                {
                    return "Sikertelen";
                }
                else if (lenght > MaxRoute())
                {
                    return "Sikertelen";
                }
                else 
                {
                    Hours += lenght / AvgSpeed;
                    return "siker";
                }
                
            }


            public override string ToString()
            {
                return $"{model},{power},{WeightCapacity},{FuelPerHour},{FuelTankSize},{AvgSpeed},{Hours}";
            }
              
        }
    }
}

