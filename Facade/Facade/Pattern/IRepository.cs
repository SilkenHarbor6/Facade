namespace Facade.Pattern
{
    using global::Facade.Model;
    using System.Collections.Generic;
    public interface IRepository
    {
        #region Metodos

        List<Persona> GetAll();//Obtener todas las personas
        bool PersonOperation(Persona item,Facade.Operacion operacion,Persona old = default(Persona));

        #endregion
    }
}
