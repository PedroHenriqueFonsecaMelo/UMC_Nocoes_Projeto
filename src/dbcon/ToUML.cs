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
            MethodInfo[] metmet = classe.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Static);

            StringBuilder table = new StringBuilder();

            int i = 0;
            if (classe.IsInterface)
            {
                table.Append("[<< Interface>> " + classe.Name + "|");
            }
            else if (classe.IsAbstract)
            {
                table.Append("[_" + classe.Name + "_|");
            }
            else
            {
                table.Append("[" + classe.Name + "|");
            }

            ClasseAtributos(Fields, table, classe, i);
            i = 0;
            ClasseMetodos(metmet, table, classe, i);
            ClasseHeranca(classe);

            Console.WriteLine(table.ToString());

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
            if (f.FieldType.IsAbstract && (f.FieldType.Namespace.Contains("UMC_Nocoes_Projeto") || f.FieldType.Namespace.Contains("main")))
            {
                Console.WriteLine("[" + classe.Name + "] -.-> [" + f.FieldType.Name + "]");

            }
            else if (f.FieldType.IsClass && (f.FieldType.Namespace.Contains("UMC_Nocoes_Projeto") || f.FieldType.Namespace.Contains("main")))
            {
                Console.WriteLine("[" + classe.Name + "] <>-> [" + f.FieldType.Name + "]");
            }
        }

        private static void UmlMetodos(StringBuilder table, string name, string tipo, MethodInfo f, Type classe)
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
        }
        private static string UmlMetodosParameters(MethodInfo metmet)
        {
            StringBuilder str = new StringBuilder("(");
            int size = metmet.GetParameters().Length;
            int index = 0;

            foreach (ParameterInfo pParameter in metmet.GetParameters())
            {
                
                if (index < size)
                {
                    
                    str.Append(pParameter.ParameterType.Name);
                    str.Append(",");
                }
                index ++;

            }
            str.Append(")");
            return str.ToString();
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
        private static void ClasseAtributos(FieldInfo[] Fields, StringBuilder table, Type classe, int i)
        {
            if (Fields.Length <= 0)
            {
                table.Append(" | ");
            }
            else
            {
                foreach (FieldInfo f in Fields)
                {

                    i++;
                    string name = f.Name;
                    string tipo = f.FieldType.Name;

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
            }

        }
        private static void ClasseMetodos(MethodInfo[] metmet, StringBuilder table, Type classe, int i)
        {
            if (metmet.Length <= 0)
            {
                table.Append(" | ");
            }
            else
            {
                foreach (MethodInfo item in metmet)
                {
                    i++;
                    //string name = metmet.Name;
                    string tipo = item.GetType().Name;

                    if (i <= metmet.Length - 1)
                    {
                        table.Append(item.Name + " " + UmlMetodosParameters(item));
                        table.Append(";");
                    }
                    else
                    {
                        table.Append(item.Name + " " + UmlMetodosParameters(item));
                        table.Append("]");
                    }
                }
            }
        }
        private static void ClasseHeranca(Type classe)
        {
            if (classe.GetInterfaces().Length > 0 && !classe.GetInterface("System.IDisposable").FullName.Contains("System.IDisposable"))
            {
                AllIntefaces(classe);
            }
            if (classe.BaseType != null && !classe.BaseType.Name.Contains("Object"))
            {
                Console.WriteLine("[" + classe.Name + "]^[" + classe.BaseType.Name + "]");
            }

        }
    }
}
