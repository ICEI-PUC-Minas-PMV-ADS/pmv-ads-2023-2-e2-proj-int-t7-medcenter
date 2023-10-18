document.addEventListener("DOMContentLoaded", function () {
    const slides = document.querySelectorAll(".carousel-slide");
    const dots = document.querySelectorAll(".carousel-dot");
  
    let currentSlide = 0;
  
    // Fun��o para exibir o slide atual
    function showSlide() {
      slides.forEach((slide, index) => {
        if (index === currentSlide) {
          slide.style.display = "block";
        } else {
          slide.style.display = "none";
        }
      });
  
      // Atualiza a classe 'active' para os dots
      dots.forEach((dot, index) => {
        dot.classList.toggle("active", index === currentSlide);
      });
    }
  
    // Fun��o para avan�ar para o pr�ximo slide
    function nextSlide() {
      currentSlide = (currentSlide + 1) % slides.length;
      showSlide();
    }
  
    // Fun��o para voltar para o slide anterior
    function prevSlide() {
      currentSlide = (currentSlide - 1 + slides.length) % slides.length;
      showSlide();
    }
  
    // Adicionar ouvintes de evento aos dots
    dots.forEach((dot, index) => {
      dot.addEventListener("click", () => {
        currentSlide = index;
        showSlide();
      });
    });
  
    // Inicializar o carrossel
    showSlide();
  
    // Alterar automaticamente o slide a cada 7 segundos
    setInterval(nextSlide, 7000);
  });
  