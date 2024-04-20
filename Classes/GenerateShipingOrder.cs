using Hackathon_2024_API.Models;
namespace Hackathon_2024_API.Classes

{
    public class GenerateShipingOrder
    {
        public List<Package> PackageToday { get; set; }

        public double[] Werehouse = new double[2];



        public GenerateShipingOrder(List<Package> PackageToday, double[] Almacen) {
            
            this.PackageToday = PackageToday;
            this.Werehouse = Almacen;
            
        }

        public void CalculateDistancesWereHouse() {

            double latA = Werehouse[0];
            double longA = Werehouse[1];


            foreach (Package package in this.PackageToday) {

                double latB = package.Latitude;
                double longB = package.Longuitud;

                package.distanceToWereHouse = this.distanciaEucladiana(latA, longA, latB, longB);

                
            }

            this.PackageToday =this.PackageToday.OrderBy(p => p.distanceToWereHouse).ToList();
        }

        public List<Shiping> AsignToCarriesShiping(List<ApplicationUser> carries) {
            int k = carries.Count;
            int i = 0;

            List<Shiping> shipings = new List<Shiping>();

            //asignar k primeros lugares mas cercanos
            foreach (ApplicationUser carrier in carries) {
                Shiping newShiping = new Shiping();

                newShiping.IdCarrier = carrier.Id;
                newShiping.Packets.Add(this.PackageToday[i].Id);
                newShiping.LatAct = this.PackageToday[i].Latitude;
                newShiping.LongAct = this.PackageToday[i].Longuitud;

                shipings.Add(newShiping);
                
            }

             
            

            foreach (Package package in this.PackageToday.Skip(k)){

                List<DatosDistancias> datosDist = new List<DatosDistancias>();

                foreach (ApplicationUser carrier in carries)
                {

                }




            }



            return null;
            
        }

        public double distanciaEucladiana(double latA, double longA, double latB, double longB) {
            double distancia= Math.Sqrt(Math.Pow(latB-latA,2)+Math.Pow(longB-longA,2));
            return distancia;
        }



    }
}
