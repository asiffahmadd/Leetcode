public class Solution
{
    public int MinMoves(string[] classroom, int energy)
    {
        int m = classroom.Length;
        int n = classroom[0].Length;

        int startR = 0;
        int startC = 0;

        List<(int r, int c)> litters = new List<(int r, int c)>();

        // Find starting point and litter positions
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (classroom[i][j] == 'S')
                {
                    startR = i;
                    startC = j;
                }
                else if (classroom[i][j] == 'L')
                {
                    litters.Add((i, j));
                }
            }
        }

        int litterCount = litters.Count;

        if (litterCount == 0)
            return 0;

        // Assign a bit to every litter
        int[,] litterIndex = new int[m, n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                litterIndex[i, j] = -1;
            }
        }

        for (int i = 0; i < litterCount; i++)
        {
            litterIndex[litters[i].r, litters[i].c] = i;
        }

        int fullMask = (1 << litterCount) - 1;

        // visited[row, col, energy, mask]
        bool[,,,] visited =
            new bool[m, n, energy + 1, 1 << litterCount];

        Queue<(int r, int c, int e, int mask, int moves)> queue =
            new Queue<(int r, int c, int e, int mask, int moves)>();

        queue.Enqueue((startR, startC, energy, 0, 0));
        visited[startR, startC, energy, 0] = true;

        int[] dr = { -1, 1, 0, 0 };
        int[] dc = { 0, 0, -1, 1 };

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            int r = current.r;
            int c = current.c;
            int e = current.e;
            int mask = current.mask;
            int moves = current.moves;

            // All litter collected
            if (mask == fullMask)
                return moves;

            // If energy is 0, we can continue only from R
            if (e == 0)
            {
                if (classroom[r][c] == 'R')
                {
                    e = energy;
                }
                else
                {
                    continue;
                }
            }

            for (int d = 0; d < 4; d++)
            {
                int nr = r + dr[d];
                int nc = c + dc[d];

                // Outside grid
                if (nr < 0 || nr >= m || nc < 0 || nc >= n)
                    continue;

                // Obstacle
                if (classroom[nr][nc] == 'X')
                    continue;

                int newEnergy = e - 1;

                int newMask = mask;

                // If we move onto litter, collect it
                if (classroom[nr][nc] == 'L')
                {
                    int index = litterIndex[nr, nc];
                    newMask |= (1 << index);
                }

                // Reset energy when entering R
                if (classroom[nr][nc] == 'R')
                {
                    newEnergy = energy;
                }

                if (!visited[nr, nc, newEnergy, newMask])
                {
                    visited[nr, nc, newEnergy, newMask] = true;

                    queue.Enqueue(
                        (nr, nc, newEnergy, newMask, moves + 1)
                    );
                }
            }
        }

        return -1;
    }
}