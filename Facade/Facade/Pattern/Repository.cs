namespace Facade.Pattern
{
    using global::Facade.Model;
    using System;
    using System.Collections.Generic;
    public class Repository : IRepository
    {
        #region Atributos
        private List<Persona> Personas;
        #endregion

        #region Constructor
        public Repository()
        {
            Personas = new List<Persona>();

            //Persona 1
            Persona P1 = new Persona
            {

                nombre = "Francisco",
                apellido="Flores",
                direccion="Mariona",
                edad=60

            };
            //Persona 2
            Persona P2 = new Persona
            {

                nombre = "Mauricio",
                apellido="Funes",
                direccion="Nicaragua",
                edad=55

            };
            //Persona 3
            Persona P3 = new Persona
            {

                nombre = "Salvador",
                apellido="Ceren",
                direccion="Futuramente en Mariona",
                edad=90

            };
            Personas.Add(P1);
            Personas.Add(P2);
            Personas.Add(P3);
        }
        #endregion

        #region MetodosInterfaz

        public List<Persona> GetAll()
        {
            return Personas;
        }

        public bool PersonOperation(Persona item, Facade.Operacion operacion,Persona old = default(Persona))
        {
            try
            {
                int index;
                switch (operacion)
                {
                    case Facade.Operacion.Save:
                        Personas.Add(item);
                        break;
                    case Facade.Operacion.Update:
                        index = Personas.FindIndex(p => p.nombre.Equals(old.nombre) &&
                                                    p.apellido.Equals(old.apellido) &&
                                                    p.direccion.Equals(old.direccion) &&
                                                    p.edad == old.edad);
                        Personas[index] = item;
                        break;
                    case Facade.Operacion.Delete:
                        index = Personas.FindIndex(p => p.nombre.Equals(item.nombre) &&
                                                    p.apellido.Equals(item.apellido) &&
                                                    p.direccion.Equals(item.direccion) &&
                                                    p.edad == item.edad);
                        Personas.RemoveAt(index);
                        break;
                    default:
                        return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion

    }
}
