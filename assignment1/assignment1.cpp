#include <iostream>

// task 1
int findMinimumHidden(int* arr, int i, int size, int min) {
    if (i == size) return min;
    if (arr[i] < min) {
        min = arr[i];
    }
    return findMinimumHidden(arr, ++i, size, min);
}

int findMinimum(int* arr, int size) {
    return findMinimumHidden(arr, 1, size, arr[0]);
}

// task 2
double calculateAverageHidden(int* arr, int i, int size) {
    if (i == size) return 0;
    return (double)arr[i]/size + calculateAverageHidden(arr, ++i, size);
}

double calculateAverage(int* arr, int size) {
    return calculateAverageHidden(arr, 0, size);
}

// task 3
bool isPrime(int number, int checker) {
    if (checker < 2) {
        return true;
    }
    if (number < 2) {
        return false;
    }

    if (number % checker == 0) {
        return false;
    } else {
        isPrime(number, --checker);
    }
}

void isPrime(int number) {
    std::cout << (isPrime(number, number-1) ? "Prime!" : "Not prime!");
}

// task 4
int factorial(int number) {
    if (number == 1) {
        return 1;
    }
    return number * factorial(--number);
}

// task 5
int fibonacci(int number) {
    if (number < 2 && number > 0) return 1;
    if (number == 0) return 0;
    return fibonacci(number-1) + fibonacci(number-2);
}

// task 6
double pow(int number, int degree) {
    if (degree == 0) return 1.0;
    if (degree > 0) return (number * pow(number, --degree));
    return (1/(double)number) * pow(number, ++degree);
}

// task 7
void findPermutationsHidden(char letters[], int l, int r) {
    if (l == r) {
        std::cout << letters << std::endl;
    } else {
        for (int i = l; i <= r; i++) {
            std::swap(letters[l], letters[i]);
            findPermutationsHidden(letters, l + 1, r);
            std::swap(letters[l], letters[i]);
        }
    }
}

char* StringToCharArray(std::string str) {
    char* arr = new char(str.size());
    for (int i = 0; i < str.size(); i++) {
        arr[i] = str[i];
    }
    return arr;
}

void findPermutations(std::string word) {
    findPermutationsHidden(StringToCharArray(word), 0, word.size());
}

// task 8
bool hasOnlyNumbers(std::string input, int i) {
    if (i == input.length()) return true;

    if (input[i] >= '0' and input[i] <= '9') {
        hasOnlyNumbers(input, ++i);
    } else {
        return false;
    }
}

void hasOnlyNumbers(std::string str) {
    std::cout << hasOnlyNumbers(str, 0) ? "Yes" : "No";
}

// task 9
int binomialCoefficient(int bot, int top) {
    if (top > bot) {
        std::cout << "k should be bigger than n!";
        return 0;
    }
    if (bot == 0 || bot == top || top == 0) {
        return 1;
    }
    return binomialCoefficient(bot - 1, top - 1) + binomialCoefficient(bot - 1, top);
}

// task 10
int findGCD(int first, int second) {
    if (first == second) {
        return first;
    }

    if (first == 0 || second == 0) {
        return first + second;
    }

    if (first > second) {
        return findGCD(first%second, second);
    } else {
        return findGCD(first, second%first);
    }

}

int main() {
    using namespace std;

    return 0;
}