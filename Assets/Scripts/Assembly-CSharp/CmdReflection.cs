using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Reflection;


public static class CmdReflection
{
    private static readonly Dictionary<sbyte, List<string>> _commandMap;

    // Static constructor, chạy 1 lần khi chương trình load class này
    static CmdReflection()
    {
        _commandMap = new Dictionary<sbyte, List<string>>();

        // Lấy tất cả Field (trường) tĩnh, public trong class Cmd
        var fields = typeof(Cmd).GetFields(BindingFlags.Public | BindingFlags.Static);

        foreach (var field in fields)
        {
            // Chỉ quan tâm tới hằng (IsLiteral == true & IsInitOnly == false)
            // => các public const sbyte 
            if (field.IsLiteral && !field.IsInitOnly && field.FieldType == typeof(sbyte))
            {
                // Lấy giá trị hằng số
                sbyte value = (sbyte)field.GetRawConstantValue();
                // Lấy tên hằng
                string name = field.Name;

                // Thêm vào dictionary
                if (!_commandMap.ContainsKey(value))
                {
                    _commandMap[value] = new List<string>();
                }
                _commandMap[value].Add(name);
            }
        }
    }

    /// <summary>
    /// Lấy danh sách các tên hằng (nếu có trùng) của một giá trị sbyte.
    /// </summary>
    public static List<string> GetCommandNames(sbyte value)
    {
        if (_commandMap.ContainsKey(value))
        {
            return _commandMap[value];
        }
        return new List<string>() { "UNKNOWN_COMMAND" };
    }

    /// <summary>
    /// Lấy tên đầu tiên (nếu có) của hằng sbyte, hoặc "UNKNOWN_COMMAND" nếu không có
    /// </summary>
    public static string GetFirstCommandName(sbyte value)
    {
        var listName = GetCommandNames(value);
        return listName.Count > 0 ? listName[0] : "UNKNOWN_COMMAND";
    }
}