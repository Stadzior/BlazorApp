(function () {
        function Hello () {
            var image = document.createElement("img");
            image.setAttribute("alt", "Hello");
            image.src = 'hello.jpeg';
            document.getElementById("placeholder").appendChild(image);
        }
})