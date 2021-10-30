namespace Fx.Concurrency
{
    using System;
    using System.Reflection;
    using System.Reflection.Emit;

    /// <summary>
    /// 
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public static class Utilities
    {
        public static Action GenerateAction(byte[] bytes)
        {
            var asmName = new AssemblyName("gdebruinassembly");
            var asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, System.Reflection.Emit.AssemblyBuilderAccess.RunAndSave);
            var module = asmBuilder.DefineDynamicModule("gdebruinmodule");
            var typeBuilder = module.DefineType("gdebruintype");
            var method = typeBuilder.DefineMethod("gdebruinmethod", MethodAttributes.Public | MethodAttributes.Static, typeof(int), new Type[0]);
            method.CreateMethodBody(bytes, bytes.Length);
            var type = typeBuilder.CreateType();
            var result = (Func<int>)type.GetMethod("gdebruinmethod").CreateDelegate(typeof(Func<int>));
            var returned = result();
            return () => result();
        }

        public static Func<T, int> GenerateAction2<T>(byte[] bytes)
        {
            var asmName = new AssemblyName("gdebruinassembly");
            var asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, System.Reflection.Emit.AssemblyBuilderAccess.RunAndSave);
            //// TODO i think you somehow need to add references to the assembly
            var module = asmBuilder.DefineDynamicModule("gdebruinmodule");
            var typeBuilder = module.DefineType("gdebruintype");
            var method = typeBuilder.DefineMethod("gdebruinmethod", MethodAttributes.Public | MethodAttributes.Static, typeof(int), new[] { typeof(T) });
            method.CreateMethodBody(bytes, bytes.Length);
            var type = typeBuilder.CreateType();
            var result = (Func<T, int>)type.GetMethod("gdebruinmethod").CreateDelegate(typeof(Func<T, int>));
            return result;
        }

        public static Func<int, int, int> GenerateAction3(byte[] bytes)
        {
            var asmName = new AssemblyName("gdebruinassembly");
            var asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, System.Reflection.Emit.AssemblyBuilderAccess.RunAndSave);
            //// TODO i think you somehow need to add references to the assembly
            var module = asmBuilder.DefineDynamicModule("gdebruinmodule");
            var typeBuilder = module.DefineType("gdebruintype");
            var method = typeBuilder.DefineMethod("gdebruinmethod", MethodAttributes.Public | MethodAttributes.Static, typeof(int), new[] { typeof(int), typeof(int) });
            method.CreateMethodBody(bytes, bytes.Length);
            var type = typeBuilder.CreateType();
            var result = (Func<int, int, int>)type.GetMethod("gdebruinmethod").CreateDelegate(typeof(Func<int, int, int>));
            return result;
        }
    }
}
