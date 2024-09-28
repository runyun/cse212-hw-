public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Create a new list for store the result
        List<double> result = new List<double>();

        // Loop through the length and multiply it to the number 
        for (int i = 1; i < length + 1; i++)
        {
            // Store to the result
            result.Add(number * i);
        }

        // Because the function is required to return a double[] object, change the List<double> to double[] before returning it.
        return result.ToArray(); 
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Get the numbers need to be put at the beginning of the array
        var clipArray = data.GetRange(data.Count - amount, amount);
        // Get the numbers without those that have been removed
        var leftArray = data.GetRange(0, data.Count - amount);
        // Clear the data object
        data.Clear();
        // Add arrays in the right order
        data.AddRange(clipArray);
        data.AddRange(leftArray);
    }
}
