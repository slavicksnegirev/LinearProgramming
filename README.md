# LinearProgramming

Таблица заполняется вручную данными из условия в файле «TableClass.cs» в 
конструкторе класса «TableClass». См. пример ниже.

    18 Вариант
Условие задачи:  q = X1 + 3•X2 -> max
                 X1 ≥ X2 - 1
                 4•X2 - 2•X1 ≥ 6
                 X1 + 2•X2 ≤ 16
                 X1,X2 ≥ 0; X1,X2 - целые
Доп. условие:    X2•Lg(X1) > 1

Ниже представлена заполненная таблица.
new List<string> { "0", "-1", "-3" },
new List<string> { "1", "-1", "1" },
new List<string> { "-6", "2", "-4" },
new List<string> { "16", "1", "2" },

Доп. условие прописывается в файле «LogicClass.cs» в конце метода 
«CheckTheEndOfTheSolution» (строка: 140). В случае, если его нет просто 
заккоментируйте проверку.

    Правила ввода доп. условия:
1. Вводите обратное условие, то есть, если условие (... > 1),
то для проверки введите (... <= 1)
2. Необходимая переменная с индексом i прописывается
следующим образом: Solution["X" + i].ToDouble()

Ниже прописано доп. условие из 18 варианта (X2•Lg(X1) > 1)
if (Solution["X" + 2].ToDouble() * Math.Log10(Solution["X" + 1].ToDouble()) <= 1)
{
    return false;
}
