function Hello () {
    var image = document.createElement("img");
    image.setAttribute("alt", "Hello");
    image.setAttribute("Height", "270");
    image.setAttribute("Width", "480");
    image.src = 'js/hello.jpeg';
    document.getElementById("placeholder").appendChild(image);
}