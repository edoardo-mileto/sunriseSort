using Random = System.Random;

namespace sunriseSort
{
    public abstract class SunriseSort
    {
        /// <summary>
        /// Sorts the array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="data">The array to sort.</param>
        public static void Sort<T>(T[] data)
            where T : IComparable
        {
            // Temp array used for the merging
            T[] temp = new T[data.Length];
            Sort(data, temp, 0, data.Length - 1);
        }

        /// <summary>
        /// Sorts a segment of the <paramref name="data"/> array from <paramref name="lx"/> to <paramref name="rx"/>.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="data">The array to be sorted.</param>
        /// <param name="temp">The temp array used for the merging.</param>
        /// <param name="lx">The start index of the segment to sort.</param>
        /// <param name="rx">The end index of the segment to sort.</param>
        private static void Sort<T>(T[] data, T[] temp, int lx, int rx) where T : IComparable
        {
            // Splits the interval in two, sorts them,
            // and them merges them back together
            if (lx < rx)
            {
                int cx = (lx + rx) / 2;
                Sort(data, temp, lx, cx);
                Sort(data, temp, cx + 1, rx);
                Merge(data, temp, lx, cx + 1, rx);
            }
        }

        /// <summary>
        /// Merges two sorted, consecutive segments of an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="data">The array to be sorted.</param>
        /// <param name="temp">The temp array used for the merging.</param>
        /// <param name="lx">The start index of the first segment to sort.</param>
        /// <param name="cx">The start index of the second segment to sort.</param>
        /// <param name="rx">The end index of the second segment to sort.</param>
        private static void Merge<T>(T[] data, T[] temp, int lx, int cx, int rx) where T : IComparable
        {
            int endLeft = cx - 1;
            int posAux = lx;
            int numElemen = rx - lx + 1;

            // Block index (-1 = first iteration)
            int bx = -1;

            while (lx <= endLeft && cx <= rx)
                //if ((data[ lx ])< (data[cx]))
                if (data[lx].CompareTo(data[cx]) < 0)
                    //temp[posAux++]=data[sx++];
                    bx = Insert(temp, data[lx++], bx, posAux++);
                else
                    //temp[posAux++] = data[cx++];
                    bx = Insert(temp, data[cx++], bx, posAux++);

            while (lx <= endLeft)
                //temp[posAux++]=data[lx++];
                bx = Insert(temp, data[lx++], bx, posAux++);

            while (cx <= rx)
                //temp[posAux++]=data[cx++];
                bx = Insert(temp, data[cx++], bx, posAux++);

            //int bx = dx;
            //qui sovrascrive data con temp che contiene gli elementi ordinati
            for (int i = 0; i < numElemen; i++, rx--)
                data[rx] = temp[rx];
        }

        /// <summary>
        /// Inserts an element into a block.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="temp">The temp array used for the merging.</param>
        /// <param name="item">The item to insert.</param>
        /// <param name="bx">The start index of the block.</param>
        /// <param name="i">The end index of the block.</param>
        /// <returns>The new start index of the block.</returns>
        private static int Insert<T>(T[] temp, T item, int bx, int i)
            where T : IComparable
        {
            // The item needs to be inserted in the existing block
            if (bx != -1 && temp[bx].CompareTo(item) == 0)
            {
                // Swaps
                Random r = new Random();
                int j = r.Next(bx, i + 1);
                //sostituito l'utilizzo di UnityEngine con la classe Random nativa di C#
                //int j = UnityEngine.Random.Range(bx, i+1);
                temp[i] = temp[j];
                temp[j] = item;

                return bx; // Same blocks
            }
            // First insert, or element not part of the block
            else
            {
                // Appends the element
                temp[i] = item;
                return i; // New blocks
            }
        }
    }
}