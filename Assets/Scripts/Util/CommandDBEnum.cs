public sealed class CommandDBEnum{

	private readonly string name;

	public static readonly CommandDBEnum SELECT = new CommandDBEnum("SELECT ");
	public static readonly CommandDBEnum FROM = new CommandDBEnum(" FROM ");
	public static readonly CommandDBEnum WHERE = new CommandDBEnum(" WHERE ");
	public static readonly CommandDBEnum INSERT = new CommandDBEnum("INSERT ");
	public static readonly CommandDBEnum INTO = new CommandDBEnum(" INTO ");

	public static readonly CommandDBEnum VALUES = new CommandDBEnum(" VALUES ");
	public static readonly CommandDBEnum UPDATE = new CommandDBEnum("UPDATE ");
	public static readonly CommandDBEnum SET = new CommandDBEnum(" SET ");
	public static readonly CommandDBEnum DELETE = new CommandDBEnum(" DELETE ");
	public static readonly CommandDBEnum AND = new CommandDBEnum(" AND ");

	public static readonly CommandDBEnum OR = new CommandDBEnum(" OR ");
	public static readonly CommandDBEnum COMA = new CommandDBEnum(", ");
	public static readonly CommandDBEnum ORDER = new CommandDBEnum(" ORDER ");
	public static readonly CommandDBEnum BY = new CommandDBEnum("BY ");
	public static readonly CommandDBEnum ASC = new CommandDBEnum(" ASC ");

	public static readonly CommandDBEnum DESC = new CommandDBEnum(" DESC ");
	public static readonly CommandDBEnum COUNT = new CommandDBEnum("COUNT");

	private CommandDBEnum(string name){
		this.name = name;
	}

	public override string ToString (){
		return name;
	}

}