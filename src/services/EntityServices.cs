using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace main.src.services
{
    public class EntityServices
    {
        public static void AutoClassBuilder(Object ClassBuilder)
        {
            FieldInfo[] Fields = ClassBuilder.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var item in Fields)
            {

                Console.WriteLine($"{item.Name}:");

                switch (item.FieldType.Name)
                {
                    case "Int32":
                        {
                            int value = Convert.ToInt32(Console.ReadLine());
                            ClassBuilder.GetType().GetField(item.Name, BindingFlags.Instance | BindingFlags.NonPublic).SetValue(ClassBuilder, value);
                            break;
                        }

                    case "String":
                        {
                            String value = Console.ReadLine();
                            ClassBuilder.GetType().GetField(item.Name, BindingFlags.Instance | BindingFlags.NonPublic).SetValue(ClassBuilder, value);
                            break;
                        }
                    case "Boolean":
                        {
                            String prompt = Console.ReadLine();
                            Boolean value = true;

                            if (prompt.Length > 0)
                            {
                                if ((prompt.Length == 1 && prompt.ToLower().Contains('n')) || prompt.Contains("no", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    value = false;

                                }
                                else if ((prompt.Length == 1 && prompt.ToLower().Contains('y')) || prompt.Contains("yes", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    value = true;
                                }

                                ClassBuilder.GetType().GetField(item.Name, BindingFlags.Instance | BindingFlags.NonPublic).SetValue(ClassBuilder, value);
                                break;
                            }
                            break;
                        }
                    case "Float":
                        {
                            decimal value = Convert.ToDecimal(Console.ReadLine());
                            ClassBuilder.GetType().GetField(item.Name, BindingFlags.Instance | BindingFlags.NonPublic).SetValue(ClassBuilder, value);
                            break;
                        }
                }
            }
        }

        public static string ClassInfo(Type ClassInfo)
        {

            return ClassInfo.GetType()
                .GetProperties()
                .Select(info => (info.Name, Value: info.GetValue(ClassInfo, null) ?? "(null)"))
                .Aggregate(new StringBuilder(), (sb, pair) => sb.AppendLine($"{pair.Name}: {pair.Value}"), sb => sb.ToString());
        }
    }
}