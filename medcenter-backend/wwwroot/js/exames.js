var Exame = [
    {
        id: "exames_0",
        nome: "�cido �rico",
        descricao:
            "O �cido �rico � o produto final do metabolismo das purinas, estando elevado em v�rias condi��es cl�nicas al�m da gota. Somente 10% dos pacientes com hiperuricemia tem gota.",
        content: "https://drive.google.com/file/d/1hjIAnE5S_Ta5d1FJNwKOiZBxwm-bjGfz/preview",
    },
    {
        id: "exames_1",
        nome: "Albumina",
        descricao:
            "� o nome dado � detec��o de pequenas quantidades de prote�nas na urina (30 a 300 mg/24 horas) que tem import�ncia no diagn�stico e na evolu��o da nefropatia diab�tica, por indicar les�o potencialmente revers�vel.",
        content: "Albumina",
    },
    {
        id: "exames_2",
        nome: "Bi�psia",
        descricao:
            "� um exame que consiste na retirada de um fragmento de uma parte do corpo (bi�psia incisional) ou mesmo de um �rg�o ou les�o como um todo (bi�psia excisional). Na maioria das vezes, quando usamos o termo �bi�psia�, estamos nos referindo a bi�psia incisional.",
        content: "Bi�psia",
    },
    {
        id: "exames_3",
        nome: "C�lcio",
        descricao:
            "O exame de c�lcio no sangue � feito para triagem, diagn�stico e monitoramento de v�rias condi��es relacionadas aos ossos, cora��o, nervos, rins e dentes.",
        content: "C�lcio",
    },
    {
        id: "exames_4",
        nome: "Chumbo",
        descricao:
            "Este exame serve para a monitoriza��o biol�gica de indiv�duos expostos ao chumbo e para o diagn�stico de intoxica��o acidental por esse elemento, que possui efeito acumulativo e � amplamente distribu�do no meio ambiente.",
        content: "Chumbo",
    },
    {
        id: "exames_5",
        nome: "Cloretos",
        descricao:
            "Cloretos, cloro ou cloremia � uma an�lise laboratorial usada para avalia��o de dist�rbios do equil�brio hidroeletrol�tico e �cido b�sico.",
        content: "Cloretos",
    },
    {
        id: "exames_6",
        nome: "Colesterol",
        descricao:
            "O colesterol � um tipo de gordura que tem um papel fundamental na nossa sa�de. Ele participa de diversas fun��es importantes no organismo, desde a produ��o de certos horm�nios at� ajudar na forma��o das membranas de todas as nossas c�lulas",
        content: "Colesterol",
    },
    {
        id: "exames_7",
        nome: "Covid-19",
        descricao:
            "O Teste Sorol�gico para COVID-19 - IgA � indicado para pacientes com suspeita de COVID-19 com 8 ou mais dias de sintomas. Idealmente, deve ser solicitado junto com a sorologia IgG, para melhor interpreta��o do resultado.",
        content: "Covid-19",
    },
    {
        id: "exames_8",
        nome: "Creatinina",
        descricao:
            "A creatinina � um composto originado da creatina e que � filtrado e eliminado pelos rins. Ent�o medir as taxas dessa subst�ncia no sangue � uma maneira de avaliar a sa�de renal de um paciente.",
        content: "Creatinina",
    },
    {
        id: "exames_9",
        nome: "Radiografia",
        descricao:
            "O Raio-X � um exame de imagem n�o-invasivo, que funciona usando radia��o em baixas doses para identificar rapidamente altera��es na estrutura de ossos e de �rg�os.",
        content: "Radiografia",
    },
    {
        id: "exames_10",
        nome: "Resson�ncia Magn�tica",
        descricao:
            "A resson�ncia magn�tica � um exame de imagem que utiliza ondas eletromagn�ticas para auxiliar em um diagn�stico mais preciso.",
        content: "Resson�ncia",
    },
    {
        id: "exames_11",
        nome: "Tomografia",
        descricao:
            "A tomografia computadorizada � um exame de imagem que utiliza radia��o ionizante para auxiliar em um diagn�stico mais preciso e ter uma vis�o mais detalhada dos org�os internos e esqueleto.",
        content: "Tomografia",
    },
    {
        id: "exames_12",
        nome: "Ultrassonografia",
        descricao:
            "A ultrassonografia � um exame que utiliza ondas sonoras para auxiliar em um diagn�stico r�pido e preciso. Muito utilizado em exames pr�-natal e avalia��o de parte mole do corpo.",
        content: "Ultrassonografia",
    },
];

function ExibirExame() {
    var textoHTML = "";
    for (let x = 0; x < Exame.length; x++) {
        let nome = Exame[x].nome;
        let descricao = Exame[x].descricao;
        textoHTML += `<li class="exames__item" onclick="AbrirModal(event)"> <h3><strong>${nome}</strong></h3> ${descricao} <a href="#" class="botao__agendar" >Agendar</a> </li>`;
        var exames__lista = document.getElementById("exames__lista");
        exames__lista.innerHTML = textoHTML;
    }
}


var ExameImg = [
    {
        nome: "Radiografia",
        descricao:
            "O Raio-X � um exame de imagem n�o-invasivo, que funciona usando radia��o em baixas doses para identificar rapidamente altera��es na estrutura de ossos e de �rg�os.",
    },
    {
        nome: "Resson�ncia Magn�tica",
        descricao:
            "A resson�ncia magn�tica � um exame de imagem que utiliza ondas eletromagn�ticas para auxiliar em um diagn�stico mais preciso."
    },
    {
        nome: "Tomografia",
        descricao:
            "A tomografia computadorizada � um exame de imagem que utiliza radia��o ionizante para auxiliar em um diagn�stico mais preciso e ter uma vis�o mais detalhada dos org�os internos e esqueleto."
    },
    {
        nome: "Ultrassonografia",
        descricao:
            "A ultrassonografia � um exame que utiliza ondas sonoras para auxiliar em um diagn�stico r�pido e preciso. Muito utilizado em exames pr�-natal e avalia��o de parte mole do corpo."
    },
];

function ExibirExameImg() {
    var textoHTML = "";
    for (let x = 0; x < ExameImg.length; x++) {
        let nome = ExameImg[x].nome;
        let descricao = ExameImg[x].descricao;
        textoHTML += `<li class="exames__item"> <h3><strong>${nome}</strong></h3> ${descricao} <a href="#" class="botao__agendar">Agendar</a> </li>`;
        var exames__lista = document.getElementById("exames__lista");
        exames__lista.innerHTML = textoHTML;
    }
}


var ExameClinico = [
    {
        nome: "�cido �rico",
        descricao:
            "O �cido �rico � o produto final do metabolismo das purinas, estando elevado em v�rias condi��es cl�nicas al�m da gota. Somente 10% dos pacientes com hiperuricemia tem gota.",
    },
    {
        nome: "Albumina",
        descricao:
            "� o nome dado � detec��o de pequenas quantidades de prote�nas na urina (30 a 300 mg/24 horas) que tem import�ncia no diagn�stico e na evolu��o da nefropatia diab�tica, por indicar les�o potencialmente revers�vel.",
    },
    {
        nome: "Bi�psia",
        descricao:
            "� um exame que consiste na retirada de um fragmento de uma parte do corpo (bi�psia incisional) ou mesmo de um �rg�o ou les�o como um todo (bi�psia excisional). Na maioria das vezes, quando usamos o termo �bi�psia�, estamos nos referindo a bi�psia incisional.",
    },
    {
        nome: "C�lcio",
        descricao:
            "O exame de c�lcio no sangue � feito para triagem, diagn�stico e monitoramento de v�rias condi��es relacionadas aos ossos, cora��o, nervos, rins e dentes.",
    },
    {
        nome: "Chumbo",
        descricao:
            "Este exame serve para a monitoriza��o biol�gica de indiv�duos expostos ao chumbo e para o diagn�stico de intoxica��o acidental por esse elemento, que possui efeito acumulativo e � amplamente distribu�do no meio ambiente.",
    },
    {
        nome: "Cloretos",
        descricao:
            "Cloretos, cloro ou cloremia � uma an�lise laboratorial usada para avalia��o de dist�rbios do equil�brio hidroeletrol�tico e �cido b�sico.",
    },
    {
        nome: "Colesterol",
        descricao:
            "O colesterol � um tipo de gordura que tem um papel fundamental na nossa sa�de. Ele participa de diversas fun��es importantes no organismo, desde a produ��o de certos horm�nios at� ajudar na forma��o das membranas de todas as nossas c�lulas",
    },
    {
        nome: "Covid-19",
        descricao:
            "O Teste Sorol�gico para COVID-19 - IgA � indicado para pacientes com suspeita de COVID-19 com 8 ou mais dias de sintomas. Idealmente, deve ser solicitado junto com a sorologia IgG, para melhor interpreta��o do resultado.",
    },
    {
        nome: "Creatinina",
        descricao:
            "A creatinina � um composto originado da creatina e que � filtrado e eliminado pelos rins. Ent�o medir as taxas dessa subst�ncia no sangue � uma maneira de avaliar a sa�de renal de um paciente.",
    },
];

function ExibirExameClinico() {
    var textoHTML = "";
    for (let x = 0; x < ExameClinico.length; x++) {
        let nome = ExameClinico[x].nome;
        let descricao = ExameClinico[x].descricao;
        textoHTML += `<li class="exames__item"> <h3><strong>${nome}</strong></h3> ${descricao} <a href="#" class="botao__agendar">Agendar</a> </li>`;
        var exames__lista = document.getElementById("exames__lista");
        exames__lista.innerHTML = textoHTML;
    }
}


function AbrirModal(event) {
    var parentId = event.currentTarget.id;
    const settingModal = document.getElementById("display-modal");
    settingModal.innerHTML = "";
    const divModalContent = '<div class="close-modal" id="close-modal"></div> <div class="modal-content" id="modal-content"></div>';
    settingModal.insertAdjacentHTML("beforeend", divModalContent);
    const createCloseButtonModal = document.getElementById("close-modal");
    createCloseButtonModal.insertAdjacentHTML( "beforeend", '<button class="close" onclick="FecharModal()">x</button>');

    var iframe = document.createElement("iframe");
    var src_iframe;

    for (var i = 0; i < Exame.length; i++) {
        console.log('Exam ID:', Exame[i].id, 'Content:', Exame[i].content);
        if (Exame[i].id === parentId) {
            src_iframe = Exame[i].content;
            break;
        }
    }

    iframe.src = src_iframe;

    var container = document.getElementById("modal-content");
    container.appendChild(iframe);

    settingModal.appendChild(container);

    let el = document.getElementById("display-modal");
    el.style.display = 'block';

    var elements = document.querySelectorAll('body > *:not(.display-modal)');

    scroll(0, 1);

}

function FecharModal() {
    var elements = document.querySelectorAll('body > *:not(.display-modal)');
    for (var i = 0; i < elements.length; i++) {
        elements[i].style.filter = '';
    }
    let el = document.getElementById("display-modal");
    el.style.display = 'none';
}