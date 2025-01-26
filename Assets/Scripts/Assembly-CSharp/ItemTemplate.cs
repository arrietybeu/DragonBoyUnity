public class ItemTemplate
{
    public short id;

    public sbyte type;

    public sbyte gender;

    public string name;

    public string[] subName;

    public string description;

    public sbyte level;

    public short iconID;

    public short part;

    public bool isUpToUp;

    public int w;

    public int h;

    public int strRequire;

    public ItemTemplate(short templateID, sbyte type, sbyte gender, string name,
        string description, sbyte level, int strRequire, short iconID, short part, bool isUpToUp)
    {
        this.id = templateID;
        this.type = type;
        this.gender = gender;
        this.name = name;
        this.name = Res.changeString(this.name);
        this.description = description;
        this.description = Res.changeString(this.description);
        this.level = level;
        this.strRequire = strRequire;
        this.iconID = iconID;
        this.part = part;
        this.isUpToUp = isUpToUp;

        string filepath = "E://SQL//item_template.sql";

        string querry = $"INSERT INTO item_template(id, type, gender, name, description, level, strRequire, icon_id, part, is_up_top)" +
            $" VALUE ({this.id}, {this.type}, {this.gender}, '{this.name}', '{this.description}', {this.level}, {this.strRequire}, {this.iconID}, {this.part}, {this.isUpToUp});\n";

        System.IO.File.AppendAllText(filepath, querry);
    }

}
