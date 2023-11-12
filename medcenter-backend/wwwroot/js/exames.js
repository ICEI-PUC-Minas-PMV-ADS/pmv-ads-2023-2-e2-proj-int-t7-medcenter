var Exame = [
    {
        nome: "Ácido Úrico",
        descricao:
            "O ácido úrico é o produto final do metabolismo das purinas, estando elevado em várias condições clínicas além da gota. Somente 10% dos pacientes com hiperuricemia tem gota.",
    },
    {
        nome: "Albumina",
        descricao:
            "É o nome dado à detecção de pequenas quantidades de proteínas na urina (30 a 300 mg/24 horas) que tem importância no diagnóstico e na evolução da nefropatia diabética, por indicar lesão potencialmente reversível.",
    },
    {
        nome: "Biópsia",
        descricao:
            "É um exame que consiste na retirada de um fragmento de uma parte do corpo (biópsia incisional) ou mesmo de um órgão ou lesão como um todo (biópsia excisional). Na maioria das vezes, quando usamos o termo “biópsia”, estamos nos referindo a biópsia incisional.",
    },
    {
        nome: "Cálcio",
        descricao:
            "O exame de cálcio no sangue é feito para triagem, diagnóstico e monitoramento de várias condições relacionadas aos ossos, coração, nervos, rins e dentes.",
    },
    {
        nome: "Chumbo",
        descricao:
            "Este exame serve para a monitorização biológica de indivíduos expostos ao chumbo e para o diagnóstico de intoxicação acidental por esse elemento, que possui efeito acumulativo e é amplamente distribuído no meio ambiente.",
    },
    {
        nome: "Cloretos",
        descricao:
            "Cloretos, cloro ou cloremia é uma análise laboratorial usada para avaliação de distúrbios do equilíbrio hidroeletrolítico e ácido básico.",
    },
    {
        nome: "Colesterol",
        descricao:
            "O colesterol é um tipo de gordura que tem um papel fundamental na nossa saúde. Ele participa de diversas funções importantes no organismo, desde a produção de certos hormônios até ajudar na formação das membranas de todas as nossas células",
    },
    {
        nome: "Covid-19",
        descricao:
            "O Teste Sorológico para COVID-19 - IgA é indicado para pacientes com suspeita de COVID-19 com 8 ou mais dias de sintomas. Idealmente, deve ser solicitado junto com a sorologia IgG, para melhor interpretação do resultado.",
    },
    {
        nome: "Creatinina",
        descricao:
            "A creatinina é um composto originado da creatina e que é filtrado e eliminado pelos rins. Então medir as taxas dessa substância no sangue é uma maneira de avaliar a saúde renal de um paciente.",
    },
    {
        nome: "Radiografia",
        descricao:
            "O Raio-X é um exame de imagem não-invasivo, que funciona usando radiação em baixas doses para identificar rapidamente alterações na estrutura de ossos e de órgãos.",
    },
    {
        nome: "Ressonância Magnética",
        descricao:
            "A ressonância magnética é um exame de imagem que utiliza ondas eletromagnéticas para auxiliar em um diagnóstico mais preciso."
    },
    {
        nome: "Tomografia",
        descricao:
            "A tomografia computadorizada é um exame de imagem que utiliza radiação ionizante para auxiliar em um diagnóstico mais preciso e ter uma visão mais detalhada dos orgãos internos e esqueleto."
    },
    {
        nome: "Ultrassonografia",
        descricao:
            "A ultrassonografia é um exame que utiliza ondas sonoras para auxiliar em um diagnóstico rápido e preciso. Muito utilizado em exames pré-natal e avaliação de parte mole do corpo."
    },
];

function ExibirExame() {
    var textoHTML = "";
    for (let x = 0; x < Exame.length; x++) {
        let nome = Exame[x].nome;
        let descricao = Exame[x].descricao;
        textoHTML += `<li class="exames_item"> <h3><strong>${nome}</strong></h3> ${descricao} <a href="#" class="botao__agendar">Agendar</a> </li>`;
        var exames_lista = document.getElementById("exames_lista");
        exames_lista.innerHTML = textoHTML;
    }
}
