using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


namespace UMC_Nocoes_Projeto.src.dbcon
{
    public static class ToUML
    {


        private static void UML(Type classe)
        {


            FieldInfo[] Fields = classe.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.NonPublic);
            StringBuilder table = new StringBuilder();
            String name, tipo;
            int i = 0;
            table.Append("[" + classe.Name + "|");



            foreach (FieldInfo f in Fields)
            {

                i++;
                name = f.Name;
                tipo = f.FieldType.Name;


                if (i <= Fields.Length - 1)
                {
                    UmlAtributos(table, name, tipo, f, classe);
                    table.Append(";");
                }
                else
                {
                    UmlAtributos(table, name, tipo, f, classe);
                    table.Append(" | ");
                }
            }
            if (Fields.Length <= 0)
            {
                table.Append(" | ");
            }

            MethodInfo[] metmet = classe.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Static);
            i = 0;

            foreach (MethodInfo item in metmet)
            {
                i++;
                
                if (i <= metmet.Length - 1)
                {
                    table.Append(item);
                    table.Append(";");
                }
                else
                {
                    table.Append(item);
                    table.Append("]");
                }
            }
            Console.WriteLine(table.ToString());

            if (classe.GetInterfaces().Length > 0 && !classe.GetInterface("System.IDisposable").FullName.Contains("System.IDisposable"))
            {
                AllIntefaces(classe);
            }

            if (classe.BaseType != null && !classe.BaseType.Name.Contains("Object"))
            {
                Console.WriteLine("[" + classe.Name + "]^[" + classe.BaseType.Name + "]");
            }
            Console.WriteLine();
        }

        private static void AllIntefaces(Type classe)
        {
            var allInterfaces = new HashSet<Type>(classe.GetInterfaces());
            var toRemove = new HashSet<Type>();
            //Considering class A given above allInterfaces contain A and B now
            foreach (var implementedByMostDerivedClass in allInterfaces)
            {
                //For interface A this will only contain single element, namely B
                //For interface B this will an empty array
                foreach (var implementedByOtherInterfaces in implementedByMostDerivedClass.GetInterfaces())
                {
                    toRemove.Add(implementedByOtherInterfaces);
                }
            }

            //Finally remove the interfaces that do not belong to the most derived class.
            allInterfaces.ExceptWith(toRemove);

            Console.WriteLine(string.Join(classe.Name + "--->", allInterfaces));
        }

        private static void UmlAtributos(StringBuilder table, string name, string tipo, FieldInfo f, Type classe)
        {
            if (f.IsPublic)
            {
                table.Append(" +").Append(name).Append(": ").Append(tipo);
            }
            else if (f.IsPrivate)
            {
                table.Append(" -").Append(name).Append(": ").Append(tipo);
            }
            else
            {
                table.Append(" #").Append(name).Append(": ").Append(tipo);
            }

            if (f.FieldType.IsClass && (f.FieldType.Namespace.Contains("UMC_Nocoes_Projeto") || f.FieldType.Namespace.Contains("main")))
            {
                Console.WriteLine("["+classe.Name + "] <>-> [" + f.FieldType.Name+"]");
            }
        }

        private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                      .ToArray();
        }
        public static void UmlGenerator(string Namespace)
        {
            Type[] typelist = GetTypesInNamespace(Assembly.GetExecutingAssembly(), Namespace);
            for (int i = 0; i < typelist.Length; i++)
            {
               if (!typelist[i].Name.Equals("Program") && !typelist[i].Name.Equals("main_teste"))
               {
                 UML(typelist[i]);
               }
            }
        }
    }
}
