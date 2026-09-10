namespace InterfaceSegregation;

internal interface ILiveDealerTable
{
    // This separate contract lets table-capable terminals opt in without coupling slot-only machines to it.
    /// <summary>
    /// Opens a live dealer table for a game session.
    /// </summary>
    /// <param name="tableName">The live table name.</param>
    /// <returns>The table confirmation.</returns>
    string OpenTable(string tableName);
}
