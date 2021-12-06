using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
        }

        public MappingProfile(Assembly assembly)
        {
            ApplyMappingsFromAssembly(Assembly.GetCallingAssembly());
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
            ApplyMappingsFromAssembly(Assembly.GetEntryAssembly());
            ApplyMappingsFromAssembly(assembly);
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Any(i => i == typeof(IMapping)))
                .ToList();

            foreach (var type in types)
            {
                try
                {
                    var instance = Activator.CreateInstance(type, true);
                    var methodInfo = type.GetMethod("MappingProfile");

                    methodInfo?.Invoke(obj: instance, parameters: new object[] { this }); 
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
