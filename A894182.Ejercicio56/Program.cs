using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A894182.Ejercicio56
{
    class Program
    {
        static void Main(string[] args)
        {

            Dieta vegana = new Dieta("Vegana", 1);
            Dieta hiperc = new Dieta("Hipercalorica", 2);
            Dieta carneB = new Dieta("Carnes Blancas", 3);
             
            List<Dieta> dietas = new List<Dieta>();
            dietas.Add(vegana);
            dietas.Add(hiperc);
            dietas.Add(carneB);

            Plato arroz = new Plato("Arroz (media taza)", 150);
            Plato mila = new Plato("Milanesa", 205);
            Plato ensalada = new Plato("Ensalada", 100);
            Plato huevo = new Plato("Huevo frito", 350);
            Plato fideos = new Plato("Fideos (1 plato)", 250);
            Plato pan = new Plato("Pan con manteca (2 rodajas)", 225);
            Plato helado = new Plato("Helado (una taza)", 175);
            Plato pollo = new Plato("Pechuga de pollo", 105);


            vegana.ListaPlatos.Add(arroz);
            vegana.ListaPlatos.Add(ensalada);
            hiperc.ListaPlatos.Add(mila);
            hiperc.ListaPlatos.Add(huevo);
            hiperc.ListaPlatos.Add(pan);
            hiperc.ListaPlatos.Add(helado);
            carneB.ListaPlatos.Add(pollo);
            carneB.ListaPlatos.Add(ensalada);



            Paciente nuevo = new Paciente();
            Console.WriteLine("Ingrese el nombre del paciente");
            String nombreP = Console.ReadLine();
            nuevo.Nombre = nombreP;

            Console.WriteLine("Ingrese el genero del paciente");
            Console.WriteLine("F - Femenino");
            Console.WriteLine ("M - Maculino");
            String generoP = metodosMain.ValidarGenero(Console.ReadLine());
            nuevo.Sexo = generoP;

            Console.WriteLine("Ingrese el peso del paciente");
            Boolean pesoOk = Double.TryParse(Console.ReadLine(), out Double pesoP);
            while (!pesoOk) {
                Console.WriteLine("ERROR. Ingrese el peso correcto del paciente");
                pesoOk = Double.TryParse(Console.ReadLine(), out pesoP);
            }
            nuevo.Peso = pesoP;

            nuevo.calcularCalorias();

            Console.WriteLine("El paciente " + nuevo.Nombre+ " puede consumir: ");
            Console.WriteLine(nuevo.CaloriasMax + " calorias como maximo.");
            Console.WriteLine(nuevo.CaloriasMin + " calorias como minimo.");
            Console.WriteLine(nuevo.CaloriasMax + " calorias como maximo.");
            Console.WriteLine("¿Desea ver las dietas? ");

            Console.WriteLine("S - Si");
            Console.WriteLine("N - No");

            String inputD = (Console.ReadLine()).ToUpper();

            if (inputD.Equals("S"))
            {
                foreach (Dieta d in dietas) { 
                metodosMain.MostrarDieta(d);
                }

            }
            else {
                Console.WriteLine("Adios");
                Console.ReadKey();
            }

            Console.WriteLine("¿Desea asignarle una dieta a " + nuevo.Nombre + "?");

            Console.WriteLine("S - Si");
            Console.WriteLine("N - No");
            inputD = (Console.ReadLine()).ToUpper();


            if (inputD.Equals("S"))
            {
                foreach (Dieta d in dietas)
                {
                    Console.WriteLine(d.Codigo +" - "+ d.Nombre_dieta);
                }
                Boolean okO = int.TryParse(Console.ReadLine(), out int opcionD);

                while (!okO) {
                    Console.WriteLine("ERROR. Ingrese el codigo correcto");
                    pesoOk = Double.TryParse(Console.ReadLine(), out pesoP);
                }
                switch(opcionD){
                    case 1:
                        nuevo.Dieta = vegana;
                        break;
                    case 2:
                        nuevo.Dieta = hiperc;
                        break;
                    case 3:
                        nuevo.Dieta = carneB;
                        break;
                }

                Console.WriteLine("Asignacion exitosa!");
               
            }
            else
            {
                Console.WriteLine("Adios");
                Console.ReadKey();
            }



            Console.ReadKey();
        }


  
    }

    class metodosMain {

 
            public static String ValidarGenero(String input)
            {
            Boolean ok = false;

            while (!ok)
            {

                if (input.ToUpper().Equals("F") || input.ToUpper().Equals("M"))
                {
                    input = input.ToUpper();
                    ok = true;
                }
                else
                {

                    {
                        Console.WriteLine("Error. Ingrese el genero del paciente:");
                        input = Console.ReadLine();
                    }
                }
            }

            return input;
        }

        public static void MostrarDieta(Dieta d) {

            Console.WriteLine("Codigo "+ d.Codigo);
            Console.WriteLine("La dieta "+ d.Nombre_dieta+ " incluye: ");
            foreach (Plato p in d.ListaPlatos) {

                Console.WriteLine(p.Nombre + " - " + p.Calorias + "calorias");
            }

        }



    }

    class Plato {

        private String nombre;
        private int calorias;

        public Plato(string nombre, int calorias)
        {
            this.Nombre = nombre;
            this.Calorias = calorias;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Calorias { get => calorias; set => calorias = value; }
    }

    class Dieta {

        private String nombre_dieta;
        private int codigo;
        private List<Plato> listaPlatos = new List<Plato>();

        public Dieta(string nombre_dieta, int codigo)
        {
            this.Nombre_dieta = nombre_dieta;
            this.Codigo = codigo;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nombre_dieta { get => nombre_dieta; set => nombre_dieta = value; }

        internal List<Plato> ListaPlatos { get => listaPlatos; set => listaPlatos = value; }
    }

    class Paciente {

        private String nombre;
        private String sexo;
        private double peso;
        private int caloriasMin;
        private int caloriasMax;
        private Dieta dieta;

        public string Nombre { get => nombre; set => nombre = value; }
        public String Sexo { get => sexo; set => sexo = value; }
        public double Peso { get => peso; set => peso = value; }
        public int CaloriasMin { get => caloriasMin; set => caloriasMin = value; }
        public int CaloriasMax { get => caloriasMax; set => caloriasMax = value; }
        internal Dieta Dieta { get => dieta; set => dieta = value; }

        public void calcularCalorias() {

            if (this.Sexo.Equals("F"))
            {
                this.CaloriasMin = (int)Math.Floor(this.Peso * 20);
                this.CaloriasMax = (int)Math.Floor(this.CaloriasMin * 1.5);
            }
            else {
                this.CaloriasMin = (int)Math.Floor(this.Peso * 22);
                this.CaloriasMax = (int)Math.Floor(this.CaloriasMin * 1.5);
            }

        }

    }
}
