# ChatFront

## 前端考題
當設計前端閉包（Front-end Closure）的考題時，我們會專注在JavaScript閉包（Closures）的概念上，這是前端開發中一個重要的主題。以下是一系列的考題，旨在測試對閉包概念的理解及應用：

### 基礎概念
1. 解釋什麼是JavaScript的閉包，並給出一個簡單的例子。
2. 閉包如何使得函數訪問到其被創建時的作用域中的變量？

### 理解與應用
3. 給出下面代碼片段，解釋為什麼`console.log`會輸出指定的數字。試著解釋閉包在這個例子中如何工作。
    ```javascript
    function createCounter() {
        let count = 0;
        return function() {
            count++;
            console.log(count);
        };
    }
    const counter = createCounter();
    counter(); // 1
    counter(); // 2
    ```
4. 下列代碼將輸出什麼，為什麼？如果它不按預期工作，該如何修改？
    ```javascript
    for (var i = 0; i < 3; i++) {
        setTimeout(function() {
            console.log(i);
        }, 1000);
    }
    ```
5. 寫一個函數`makeAdder(x)`，它返回一個新的函數，後者接受一個參數`y`，並返回`x`和`y`的和。說明這是如何利用閉包的。

### 高級應用
6. 考慮下面的代碼。`makeArmy`函數的目的是創建一個`shooter`們的軍隊，每個`shooter`都應該有各自的號碼。為什麼所有的`shooter`最終都輸出相同的數字，以及如何修正這個問題？
    ```javascript
    function makeArmy() {
        var shooters = [];
        for (var i = 0; i < 10; i++) {
            var shooter = function() { // 閉包函數
                console.log(i);
            };
            shooters.push(shooter);
        }
        return shooters;
    }
    var army = makeArmy();
    army[0](); // 10，但我們希望是 0
    army[5](); // 也是 10，但我們希望是 5
    ```
7. 解釋並展示一個例子，如何使用閉包來創建一個私有變量。為什麼在某些情況下，使用閉包來創建私有變量會比使用物件的屬性更有優勢？

這些題目涵蓋了從基本的閉包概念到更高級應用的範疇，適合不同水平的前端開發者。通过這些問題，可以有效地評估一個人對JavaScript閉包的理解程度。
