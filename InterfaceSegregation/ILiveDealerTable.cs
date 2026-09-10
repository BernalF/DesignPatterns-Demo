namespace InterfaceSegregation;

internal interface ILiveDealerTable
{
    /// <summary>
    /// Opens a live dealer table for a game session.
    /// </summary>
    /// <param name="tableName">The live table name.</param>
    /// <returns>The table confirmation.</returns>
    string OpenTable(string tableName);
}
