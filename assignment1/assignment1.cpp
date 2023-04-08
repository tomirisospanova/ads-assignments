#include <iostream>

// task 1
int findMinimum(int* arr, int i, int size, int min) {
    if (i == size) return min;
    if (arr[i] < min) {
        min = arr[i];
    }
    return findMinimum(arr, ++i, size, min);
}

// task 2
double calculateAverage(int* arr, int i, int size) {
    if (i == size) return 0;
    return (double)arr[i]/size + calculateAverage(arr, ++i, size);
}

// task 3
void isPrime(int number, int checker) {
    if (checker < 2) {
        std::cout << "Prime!";
        return;
    }
    if (number < 2) {
        std::cout << "Not prime!";
        return;
    }

    if (number % checker == 0) {
        std::cout << "Not prime!";
    } else {
        isPrime(number, --checker);
    }
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
    if (number < 2) return 1;
    return fibonacci(number-1) + fibonacci(number-2);
}

// task 6
double pow(int number, int degree) {
    if (degree == 0) return 1.0;
    else if (degree > 0) {
        return (number * pow(number, --degree));
    } else {
        return (1/(double)number) * pow(number, ++degree);
    }
}

// task 7
// string should be converted to char array
void findPermutations(char letters[], int l, int r) {
    if (l == r) {
        std::cout << letters << std::endl;
    } else {
        for (int i = l; i <= r; i++) {
            std::swap(letters[l], letters[i]);
            findPermutations(letters, l + 1, r);
            std::swap(letters[l], letters[i]);
        }
    }
}

// task 8
void isNumber(std::string input, int i) {
    if (i == input.length()) {
        std::cout << "Yes";
        return;
    }
    if (input[i] >= '0' and input[i] <= '9') {
        isNumber(input, ++i);
    } else {
        std::cout << "No";
    }
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
    return 0;
}