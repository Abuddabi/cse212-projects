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
        // Plan:
        // allocate result array of size 'length'
        // for each i -> compute number * (i+1) -> store
        // return array

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            // This loop will run 'length' times
            // On each iteration, calculate the multiple of 'number' by (i + 1)
            // Store the result in an array at index i
            result[i] = number * (i + 1);
        }

        return result;
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
        // Plan: 
        // allocate temp array, 
        // compute each element's new index (i+amount, wrap if past end),
        // fill temp
        // overwrite original list.

        // Create a new array to hold the rotated values (temporary storage)
        int[] rotated = new int[data.Count];
        for (int i = 0; i < data.Count; i++)
        {
            // Calculate the new position for each element
            int newPosition = i + amount;
            while (newPosition > (data.Count - 1))
            {
                newPosition -= data.Count;
            }
            rotated[newPosition] = data[i];
        }

        // Clear the original list and add the rotated values
        data.Clear();
        for (int i = 0; i < rotated.Length; i++)
        {
            data.Add(rotated[i]);
        }
    }
}
