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
                    double latitud_envio = shipings.FirstOrDefault(s => s.IdCarrier == carrier.Id).LatAct;
                    double longitud_envio = shipings.FirstOrDefault(s => s.IdCarrier == carrier.Id).LongAct;
                    double distancia = this.distanciaEucladiana(package.Latitude, latitud_envio, package.Longuitud, longitud_envio);

                    DatosDistancias datoDistancias = new DatosDistancias();
                    datoDistancias.id_paquete = package.Id;
                    datoDistancias.latitud_paquete = latitud_envio;
                    datoDistancias.lonitud_paquete= longitud_envio;
                    datoDistancias.distancias = distancia;
                    datoDistancias.id_shiping = carrier.Id;

                    datosDist.Add(datoDistancias);
                }

                datosDist = datosDist.OrderBy(s => s.distancias).ToList();


                var primeraDistancia = datosDist.First();
                var idEnvio = primeraDistancia.id_shiping;
                var idPaquete = primeraDistancia.id_paquete;
                var lat = primeraDistancia.latitud_paquete;
                var lon = primeraDistancia.lonitud_paquete;

                Shiping envio = shipings.FirstOrDefault(s => s.Id == idEnvio);


                if (envio != null)
                {
                    // Agregar id_paquete a la lista de id_paquetes
                    envio.Packets.Add(idPaquete);

                    // Actualizar la posición actual
                    envio.LatAct = lat;
                    envio.LongAct = lon;
                }

            }



            return shipings;
            
        }

        public double distanciaEucladiana(double latA, double longA, double latB, double longB) {
            double distancia= Math.Sqrt(Math.Pow(latB-latA,2)+Math.Pow(longB-longA,2));
            return distancia;
        }



    }
}
