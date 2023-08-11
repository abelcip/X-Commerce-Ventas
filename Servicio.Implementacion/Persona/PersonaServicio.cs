namespace Servicio.Implementacion.Persona
{
    using System;
    using System.Collections.Generic;
    using Servicio.Interfaces.Persona;
    using Servicio.Interfaces.Persona.DTOs;

    public class PersonaServicio : IPersonaServicio
    {
        private Dictionary<Type, string> _diccionario;

        public PersonaServicio()
        {
            _diccionario = new Dictionary<Type, string>();
            InicializadorDiccionario();
        }
        
        public void AgregarOpcionDiccionario(Type type, string nombre)
        {
            _diccionario.Add(type, nombre);
        }

        public long Add(PersonaDto entidad)
        {
            var persona = InstanciaPersona(entidad);

            return persona.Add(entidad);
        }
        
        public void Delete(PersonaDto entidad)
        {
            var persona = InstanciaPersona(entidad);

            persona.Delete(entidad);
        }

        public IEnumerable<PersonaDto> Get(Type tipo, string cadenaBuscar)
        {
            var persona = InstanciarPersonaPorTipo(tipo);

            return persona.Get(cadenaBuscar);
        }
        
        public PersonaDto GetById(Type tipo, long id)
        {
            var persona = InstanciarPersonaPorTipo(tipo);

            return persona.GetById(id);
        }

        public void Update(PersonaDto entidad)
        {
            var persona = InstanciaPersona(entidad);

            persona.Update(entidad);
        }

        // =========================================================== //
        // ============         Metodos Privados           =========== //
        // =========================================================== //

        private void InicializadorDiccionario()
        {
            _diccionario.Add(typeof(EmpleadoDto), "Servicio.Implementacion.Persona.Empleado");
            _diccionario.Add(typeof(ClienteDto), "Servicio.Implementacion.Persona.Cliente");
            _diccionario.Add(typeof(ProveedorDto), "Servicio.Implementacion.Persona.Proveedor");
        }

        private Persona InstanciarEntidad(string tipoEntidad)
        {
            var tipoObjeto = Type.GetType(tipoEntidad);

            if (tipoObjeto == null) return null;

            var entidad = Activator.CreateInstance(tipoObjeto) as Persona;

            return entidad;
        }

        private Persona InstanciaPersona(PersonaDto entidad)
        {
            if (!_diccionario.TryGetValue(entidad.GetType(), out var tipoEntidad))
                throw new Exception($"No hay {entidad.GetType()} para Instanciar.");

            var persona = InstanciarEntidad(tipoEntidad);

            if (persona == null) throw new Exception($"Ocurrió un error al Instanciar {entidad.GetType()}");

            return persona;
        }

        private Persona InstanciarPersonaPorTipo(Type tipo)
        {
            if (!_diccionario.TryGetValue(tipo, out var tipoEntidad))
                throw new Exception($"No hay {tipoEntidad} para Instanciar.");

            var persona = InstanciarEntidad(tipoEntidad);

            if (persona == null) throw new Exception($"Ocurrió un error al Instanciar {tipo}");

            return persona;
        }
    }
}
