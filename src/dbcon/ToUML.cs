using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace UMC_Nocoes_Projeto.src.dbcon
{
    public static class ToUML
    {


        public static void UML(Type classe)
        {
            

            FieldInfo[] Fields = classe.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            StringBuilder table = new StringBuilder();
            String name, tipo;
            int i = 0;
            table.Append("[ " + classe.Name + " |");


            foreach (FieldInfo f in Fields)
            {

                i++;
                name = f.Name;
                tipo = f.FieldType.Name;


                if (i <= Fields.Length - 1)
                {
                    UmlNivel(table, name, tipo, f);
                    table.Append(";");
                }
                else
                {
                    UmlNivel(table, name, tipo, f);
                    table.Append(" | ");
                }
            }
            if (Fields.Length <= 0)
            {
                table.Append(" | ");
            }

            MethodInfo[] metmet = classe.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            i = 0;

            foreach (MethodInfo item in metmet)
            {
                i++;
                name = item.Name;
                tipo = item.GetType().Name;


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

        }

        private static void UmlNivel(StringBuilder table, string name, string tipo, FieldInfo f)
        {
            if (f.IsPublic)
            {
                table.Append("+").Append(name).Append(": ").Append(tipo);
            }
            else if (f.IsPrivate)
            {
                table.Append("+").Append(name).Append(": ").Append(tipo);
            }
        }

    }
}
