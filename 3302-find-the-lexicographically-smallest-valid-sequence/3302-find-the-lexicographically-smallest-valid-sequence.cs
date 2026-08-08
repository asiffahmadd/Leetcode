using System;

public class Solution {
    public int[] ValidSequence(string word1, string word2) {
        int n = word1.Length;
        int m = word2.Length;

        // 1. Right-to-left matching: latest possible exact matches for suffixes
        int[] last = new int[m + 1];
        last[m] = n;
        int p = n - 1;
        for (int j = m - 1; j >= 0; j--) {
            while (p >= 0 && word1[p] != word2[j]) {
                p--;
            }
            last[j] = p;
            if (p >= 0) p--;
        }

        // 2. Left-to-right matching: earliest possible exact matches for prefixes
        int[] L = new int[m];
        p = 0;
        for (int j = 0; j < m; j++) {
            while (p < n && word1[p] != word2[j]) {
                p++;
            }
            L[j] = (p < n) ? p : int.MaxValue;
            if (p < n) p++;
        }

        // 3. Precompute if a valid mismatch exists at or after index k in word2
        bool[] hasValidMismatch = new bool[m + 1];
        for (int k = m - 1; k >= 0; k--) {
            bool canMismatchK = false;
            if (k == 0) {
                canMismatchK = (m == 1 || last[1] > 0);
            } else if (k == m - 1) {
                canMismatchK = (L[m - 2] < n - 1);
            } else {
                canMismatchK = (L[k - 1] != int.MaxValue && last[k + 1] != -1 && L[k - 1] < last[k + 1] - 1);
            }
            hasValidMismatch[k] = hasValidMismatch[k + 1] || canMismatchK;
        }

        // 4. Main greedy construction of the smallest index sequence
        int[] ans = new int[m];
        bool changed = false;
        int p1 = 0;

        for (int p2 = 0; p2 < m; p2++) {
            if (changed) {
                // Must match word2[p2] exactly
                while (p1 < n && word1[p1] != word2[p2]) {
                    p1++;
                }
                if (p1 < n && (p2 == m - 1 || last[p2 + 1] > p1)) {
                    ans[p2] = p1;
                    p1++;
                } else {
                    return new int[0];
                }
            } else {
                bool mismatchValidAtP1 = (p2 == m - 1 || last[p2 + 1] > p1);

                if (p1 < n && word1[p1] == word2[p2]) {
                    // Exact match at p1
                    bool exactValidAtP1 = (p2 == m - 1 || last[p2 + 1] > p1 || hasValidMismatch[p2 + 1]);
                    if (exactValidAtP1) {
                        ans[p2] = p1;
                        p1++;
                    } else {
                        return new int[0];
                    }
                } else if (p1 < n && mismatchValidAtP1) {
                    // Mismatch at p1 is valid and gives a smaller index
                    ans[p2] = p1;
                    p1++;
                    changed = true;
                } else {
                    // Try exact match at L[p2]
                    int exactPos = L[p2];
                    if (exactPos != int.MaxValue && exactPos >= p1 && 
                       (p2 == m - 1 || last[p2 + 1] > exactPos || hasValidMismatch[p2 + 1])) {
                        ans[p2] = exactPos;
                        p1 = exactPos + 1;
                    } else {
                        return new int[0];
                    }
                }
            }
        }

        return ans;
    }
}