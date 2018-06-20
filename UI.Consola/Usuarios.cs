using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessEntities;

namespace UI.Consola
{

    public class Usuarios
    {
        public Usuarios()
        {
            UsuarioNegocio = new BusinessLogic.UsuarioLogic();
        }
        private BusinessLogic.UsuarioLogic _UsuarioNegocio;
        public BusinessLogic.UsuarioLogic UsuarioNegocio
        {
            set { _UsuarioNegocio = value; }
            get { return _UsuarioNegocio; }
        }

        public void Menu()
        {


            int opcion = 0;
            while (opcion != 6)
            {
                Console.WriteLine("\n 1- Listado general \n 2- Consulta\n 3- Agregar \n 4- Modificar \n 5- Eliminar \n 6- Salir \n");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        ListadoGeneral();
                        break;
                    case 2:
                        Consultar();
                        break;
                    case 3:
                        Agregar();
                        break;
                    case 4:
                        Modificar();
                        break;
                    case 5:
                        Eliminar();
                        break;
                    case 6:
                        ;
                        break;
                    default:
                        Console.WriteLine("Ingrese opcion correcta");
                        break;
                }

                Console.Clear();
            }
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
            Console.ReadKey();
        }

        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            Console.WriteLine("\t\tEmail: {0}", usr.Email);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            Console.WriteLine();
        }

        
        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch(FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("Ingrese un ID valido");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
         
        public void Agregar()
        {
            Usuario us = new Usuario();
            this.PedirDatos(us);
            us.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(us);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", us.ID);
            Console.ReadKey();

        }
        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario us = UsuarioNegocio.GetOne(ID);
                this.PedirDatos(us);
                us.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(us);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("Ingrese un ID valido");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }

            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("Ingrese un ID valido");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void PedirDatos(Usuario us)
        {
            Console.WriteLine("Ingrese Nombre: ");
            us.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Apellido: ");
            us.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese Nombre de Usuario: ");
            us.NombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese Clave: ");
            us.Clave = Console.ReadLine();
            Console.WriteLine("Ingrese Email: ");
            us.Email = Console.ReadLine();
            Console.WriteLine("Ingrese Habilitacion de Usuario (1-Si / otro-No): ");
            us.Habilitado = (Console.ReadLine() == "1");
        }

    }


}
