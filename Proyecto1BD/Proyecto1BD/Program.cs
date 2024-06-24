using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1BD
{
    internal class Program
    {
        const int tamaño = 10;

        static int[] numPago = new int[tamaño];
        static string[] fecha = new string[tamaño];
        static string[] hora = new string[tamaño];
        static string[] cedula = new string[tamaño];
        static string[] nombre = new string[tamaño];
        static string[] apellido1 = new string[tamaño];
        static string[] apellido2 = new string[tamaño];
        static int[] numCaja = new int[tamaño];
        static int[] tipoServicio = new int[tamaño];
        static string[] numFactura = new string[tamaño];
        static float[] montoAPagar = new float[tamaño];
        static float[] montoComision = new float[tamaño];
        static float[] montoDeducido = new float[tamaño];
        static float[] montoPagadoCliente = new float[tamaño];
        static float[] vuelto = new float[tamaño];

        static int indiceActual = 0;
        static bool continuarEjecucion = true;

        static void Main(string[] args)
        {
            Console.Clear();
            MostrarMenuPrincipal();
        }

        public static void MostrarMenuPrincipal()
        {
            string opcion = "";
            do
            {
                string menuPrincipal = "**Menú Principal**\n";
                menuPrincipal += "1. Inicializar vectores\n";
                menuPrincipal += "2. Realizar pagos\n";
                menuPrincipal += "3. Consultar pagos\n";
                menuPrincipal += "4. Modificar pagos\n";
                menuPrincipal += "5. Eliminar pagos\n";
                menuPrincipal += "6. Submenú reportes\n";
                menuPrincipal += "7. Salir";

                Console.WriteLine(menuPrincipal);
                opcion = Console.ReadLine();


                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        IniciarVectores();
                        break;
                    case "2":
                        Console.Clear();
                        RealizarPagos();
                        break;
                    case "3":
                        Console.Clear();
                        ConsultarPagos();
                        break;
                    case "4":
                        Console.Clear();
                        ModificarPagos();
                        break;
                    case "5":
                        Console.Clear();
                        EliminarPagos();
                        break;
                    case "6":
                        Console.Clear();
                        SubMenu();
                        break;
                    case "7":
                        continuarEjecucion = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (continuarEjecucion);
        }

        public static void SubMenu()
        {
            string opcion = "";
            string menuSub = "**Submenú reportes**\n";
            menuSub += "1. Ver todos los pagos\n";
            menuSub += "2. Ver pagos por tipo de servicio\n";
            menuSub += "3. Ver pagos por código de caja\n";
            menuSub += "4. Ver dinero comisionado por servicios\n";
            menuSub += "5. Regresar al menú principal";
            
            do
            {
                Console.WriteLine(menuSub);
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        VerTodosLosPagos();
                        break;
                    case "2":
                        Console.Clear();
                        VerPagosPorTipoServicio();
                        break;
                    case "3":
                        Console.Clear();
                        VerPagosPorCodigoCaja();
                        break;
                    case "4":
                        Console.Clear();
                        VerDineroComisionado();
                        break;
                    case "5":
                        Console.Clear();
                        MostrarMenuPrincipal();
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (true);
        }

        public static void IniciarVectores()
        {
            Console.Clear();
            for (int i = 0; i < tamaño; i++)
            {
                numPago[i] = 0;
                fecha[i] = "";
                hora[i] = "";
                cedula[i] = "";
                nombre[i] = "";
                apellido1[i] = "";
                apellido2[i] = "";
                numCaja[i] = 0;
                tipoServicio[i] = 0;
                numFactura[i] = "";
                montoAPagar[i] = 0;
                montoComision[i] = 0;
                montoDeducido[i] = 0;
                montoPagadoCliente[i] = 0;
                vuelto[i] = 0;
            }
            indiceActual = 0;
            Console.WriteLine("Vectores inicializados con éxito.");
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }

        public static void RealizarPagos()
        {
            while (indiceActual < tamaño)
            {
                numPago[indiceActual] = indiceActual + 1;
                Console.WriteLine($"Número de pago: {indiceActual + 1}");

                DateTime now = DateTime.Now;
                Console.WriteLine("Fecha y hora actual:" + now);
                fecha[indiceActual] = Convert.ToString(now);

                Console.WriteLine("Ingrese su número de cédula:");
                cedula[indiceActual] = Console.ReadLine();

                Console.WriteLine("Ingrese su nombre: ");
                nombre[indiceActual] = Console.ReadLine();

                Console.WriteLine("Ingrese su primer apellido: ");
                apellido1[indiceActual] = Console.ReadLine();

                Console.WriteLine("Ingrese su segundo apellido: ");
                apellido2[indiceActual] = Console.ReadLine();

                Random randm = new Random();
                numCaja[indiceActual] = randm.Next(1, 3);

                Console.WriteLine("Ingrese el tipo de servicio por el cual realiza su pago. (1: Luz, 2: Teléfono, 3: Agua): ");
                tipoServicio[indiceActual] = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el número de factura: ");
                numFactura[indiceActual] = Console.ReadLine();

                Console.WriteLine("Ingrese el monto a pagar: ");
                montoAPagar[indiceActual] = float.Parse(Console.ReadLine());

                // Validar que el monto pagado por el cliente sea mayor o igual al monto a pagar
                Console.WriteLine("Ingrese el monto que paga el cliente: ");
                montoPagadoCliente[indiceActual] = float.Parse(Console.ReadLine());

                if (montoPagadoCliente[indiceActual] < montoAPagar[indiceActual])
                {
                    Console.WriteLine("Error: El monto pagado por el cliente es menor al monto a pagar. No se puede registrar el pago.");
                    numPago[indiceActual] = 0;
                    fecha[indiceActual] = "";
                    hora[indiceActual] = "";
                    cedula[indiceActual] = "";
                    nombre[indiceActual] = "";
                    apellido1[indiceActual] = "";
                    apellido2[indiceActual] = "";
                    numCaja[indiceActual] = 0;
                    tipoServicio[indiceActual] = 0;
                    numFactura[indiceActual] = "";
                    montoAPagar[indiceActual] = 0;
                    montoComision[indiceActual] = 0;
                    montoDeducido[indiceActual] = 0;
                    montoPagadoCliente[indiceActual] = 0;
                    vuelto[indiceActual] = 0;
                    return;
                }

                // Calcular montos de comisión y deducido
                float comision = 0;
                float montoFacturado = montoAPagar[indiceActual];
                switch (tipoServicio[indiceActual])
                {
                    case 1:
                        comision = 0.04f;
                        break;
                    case 2:
                        comision = 0.055f;
                        break;
                    case 3:
                        comision = 0.065f;
                        break;
                }

                montoComision[indiceActual] = montoFacturado * comision;
                montoDeducido[indiceActual] = montoFacturado - montoComision[indiceActual];

                Console.WriteLine($"Monto de comisión: {montoComision[indiceActual]} colones");
                Console.WriteLine($"Monto deducido: {montoDeducido[indiceActual]} colones");

                vuelto[indiceActual] = montoPagadoCliente[indiceActual] - montoAPagar[indiceActual];

                Console.WriteLine("Pago realizado correctamente.");
                indiceActual++;
                if (indiceActual >= tamaño)
                {
                    Console.WriteLine("Vectores Llenos");
                    Console.Clear();
                    break;
                }

                Console.WriteLine("¿Desea realizar otro pago? s/n: ");
                string continuar = Console.ReadLine();
                if (continuar.ToLower() != "s")
                {
                    break;
                }
            }
        }

            public static void ConsultarPagos()
        {
            Console.WriteLine("Ingrese el número de pago que desea consultar: ");
            int numeroPago = int.Parse(Console.ReadLine());

            bool encontrado = false;
            for (int i = 0; i < tamaño; i++)
            {
                if (numPago[i] == numeroPago)
                {
                    MostrarPago(i);
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Pago no se encuentra registrado.");
            }
        }

        public static void ModificarPagos()
        {
            Console.WriteLine("Ingrese el número de pago que desea modificar: ");
            int numeroPago = int.Parse(Console.ReadLine());

            bool encontrado = false;
            for (int i = 0; i < tamaño; i++)
            {
                if (numPago[i] == numeroPago)
                {
                    Edicion(i);
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Pago no se encuentra registrado.");
            }
        }

        public static void Edicion(int indice)
        {
            Console.Clear();
            MostrarPago(indice);

            string opcion = "";
            do
            {
                Console.WriteLine("**Editar Pago**");
                Console.WriteLine("1. Modificar fecha y hora");
                Console.WriteLine("2. Modificar cédula");
                Console.WriteLine("3. Modificar nombre");
                Console.WriteLine("4. Modificar primer apellido");
                Console.WriteLine("5. Modificar segundo apellido");
                Console.WriteLine("6. Modificar tipo de servicio");
                Console.WriteLine("7. Modificar número de factura");
                Console.WriteLine("8. Modificar monto pagado por el cliente");
                Console.WriteLine("9. Regresar al menú principal");

                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        DateTime now = DateTime.Now;
                        Console.WriteLine("Fecha y hora actual: " + now);
                        fecha[indice] = now.ToString();
                        break;
                    case "2":
                        Console.WriteLine("Ingrese la nueva cédula: ");
                        cedula[indice] = Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Ingrese el nuevo nombre: ");
                        nombre[indice] = Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine("Ingrese el nuevo primer apellido: ");
                        apellido1[indice] = Console.ReadLine();
                        break;
                    case "5":
                        Console.WriteLine("Ingrese el nuevo segundo apellido: ");
                        apellido2[indice] = Console.ReadLine();
                        break;
                    case "6":
                        Console.WriteLine("Ingrese el nuevo tipo de servicio (1: Luz, 2: Teléfono, 3: Agua): ");
                        tipoServicio[indice] = int.Parse(Console.ReadLine());
                        break;
                    case "7":
                        Console.WriteLine("Ingrese el nuevo número de factura: ");
                        numFactura[indice] = Console.ReadLine();
                        break;
                    case "8":
                        Console.WriteLine("Ingrese el nuevo monto pagado por el cliente: ");
                        float nuevoMontoPagado = float.Parse(Console.ReadLine());
                        if (nuevoMontoPagado < montoAPagar[indice])
                        {
                            Console.WriteLine("Error: El monto pagado por el cliente es menor al monto a pagar original. No se puede modificar el pago.");
                            return;
                        }
                        montoPagadoCliente[indice] = nuevoMontoPagado;
                        vuelto[indice] = montoPagadoCliente[indice] - montoAPagar[indice];
                        break;
                    case "9":
                        Console.Clear();
                        MostrarMenuPrincipal();
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (true);
        }

        public static void EliminarPagos()
        {
            Console.WriteLine("Ingrese el número de pago que desea eliminar: ");
            int numeroPago = int.Parse(Console.ReadLine());

            bool encontrado = false;
            for (int i = 0; i < tamaño; i++)
            {
                if (numPago[i] == numeroPago)
                {
                    EliminarPago(i);
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Pago no se encuentra registrado.");
            }
        }

        public static void EliminarPago(int indice)
        {
            for (int i = indice; i < tamaño - 1; i++)
            {
                numPago[i] = numPago[i + 1];
                fecha[i] = fecha[i + 1];
                hora[i] = hora[i + 1];
                cedula[i] = cedula[i + 1];
                nombre[i] = nombre[i + 1];
                apellido1[i] = apellido1[i + 1];
                apellido2[i] = apellido2[i + 1];
                numCaja[i] = numCaja[i + 1];
                tipoServicio[i] = tipoServicio[i + 1];
                numFactura[i] = numFactura[i + 1];
                montoAPagar[i] = montoAPagar[i + 1];
                montoComision[i] = montoComision[i + 1];
                montoDeducido[i] = montoDeducido[i + 1];
                montoPagadoCliente[i] = montoPagadoCliente[i + 1];
                vuelto[i] = vuelto[i + 1];
            }

            indiceActual--;
            Console.WriteLine("Pago eliminado con éxito.");
            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void VerTodosLosPagos()
        {
            bool hayPagos = false;
            Console.WriteLine("***** Todos los pagos *****");
            for (int i = 0; i < tamaño; i++)
            {
                if (numPago[i] != 0)
                {
                    MostrarPago(i);
                    hayPagos = true;
                }
            }

            if (!hayPagos)
            {
                Console.WriteLine("No hay pagos registrados.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        public static void VerPagosPorTipoServicio()
        {
            Console.WriteLine("Ingrese el tipo de servicio que desea consultar (1: Luz, 2: Teléfono, 3: Agua): ");
            int tipo = int.Parse(Console.ReadLine());

            bool encontrado = false;
            Console.WriteLine($"***** Pagos por tipo de servicio {tipo} *****");
            for (int i = 0; i < tamaño; i++)
            {
                if (tipoServicio[i] == tipo)
                {
                    MostrarPago(i);
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine($"No hay pagos registrados para el tipo de servicio {tipo}.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        public static void VerPagosPorCodigoCaja()
        {
            Console.WriteLine("Ingrese el número de caja que desea consultar (1, 2 o 3): ");
            int caja = int.Parse(Console.ReadLine());

            bool encontrado = false;
            Console.WriteLine($"***** Pagos por número de caja {caja} *****");
            for (int i = 0; i < tamaño; i++)
            {
                if (numCaja[i] == caja)
                {
                    MostrarPago(i);
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine($"No hay pagos registrados para el número de caja {caja}.");
            }
        }

        public static void VerDineroComisionado()
        {
            bool hayPagos = false;
            Console.WriteLine("***** Dinero comisionado por servicios *****");
            for (int i = 0; i < tamaño; i++)
            {
                if (numPago[i] != 0)
                {
                    Console.WriteLine($"Número de pago: {numPago[i]} - Comisión: {montoComision[i]} colones");
                    hayPagos = true;
                }
            }

            if (!hayPagos)
            {
                Console.WriteLine("No hay pagos registrados.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        public static void MostrarPago(int indice)
        {
            Console.WriteLine($"Número de pago: {numPago[indice]}");
            Console.WriteLine($"Fecha y hora: {fecha[indice]}");
            Console.WriteLine($"Cédula: {cedula[indice]}");
            Console.WriteLine($"Nombre completo: {nombre[indice]} {apellido1[indice]} {apellido2[indice]}");
            Console.WriteLine($"Código de caja: {numCaja[indice]}");
            Console.WriteLine($"Tipo de servicio: {ObtenerNombreTipoServicio(tipoServicio[indice])}");
            Console.WriteLine($"Número de factura: {numFactura[indice]}");
            Console.WriteLine($"Monto a pagar: {montoAPagar[indice]} colones");
            Console.WriteLine($"Monto de comisión: {montoComision[indice]} colones");
            Console.WriteLine($"Monto deducido: {montoDeducido[indice]} colones");
            Console.WriteLine($"Monto pagado por el cliente: {montoPagadoCliente[indice]} colones");
            Console.WriteLine($"Vuelto: {vuelto[indice]} colones");
            Console.WriteLine();
        }

        public static string ObtenerNombreTipoServicio(int tipo)
        {
            switch (tipo)
            {
                case 1:
                    return "Luz";
                case 2:
                    return "Teléfono";
                case 3:
                    return "Agua";
                default:
                    return "Desconocido";
            }
        }                    
    }
}
