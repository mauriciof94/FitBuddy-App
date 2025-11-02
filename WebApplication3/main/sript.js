let menu = document.querySelector('#menu-icon');
let navbar = document.querySelector('.navbar');

menu.onclick = () => {
    menu.classList.toggle('bx-x');
    navbar.classList.toggle('active');
}

window.onscroll = () => {
    menu.classList.remove('bx-x');
    navbar.classList.remove('active');
}


const typed = new Typed('.multiple-text', {
    strings: ['Nuestra App', 'FitBuddy tu Match en un Smartwatch', 'Fitbuddy tu Mejor versión', 'Soy wearable, eres wearable, Somos FitBuddy', 'Entrena con propósito, conecta con FitBuddy.', 'Donde la tecnología y el deporte se encuentran.', 'Tu red deportiva, siempre al alcance.', 'FitBuddy: personaliza, mide, supera.', 'Porque entrenar juntos es llegar más lejos.'],
    typeSpeed: 60,
    backSpeed: 60,
    backDelay: 1000,
    loop: true,
});