// dynamic pages 

(function(){

    let l1 = document.querySelector('#link01')
    let l2 = document.querySelector('#link02')
    let l3 = document.querySelector('#link03')

    l1.addEventListener('click', function(){
        document.querySelector('#menu01').classList.remove('hidden')
        document.querySelector('#menu02').classList.add('hidden')
        document.querySelector('#menu03').classList.add('hidden')

        document.querySelector('#link01').classList.add('selected')
        document.querySelector('#link02').classList.remove('selected')
        document.querySelector('#link03').classList.remove('selected')
    })

    l2.addEventListener('click', function(){
        document.querySelector('#menu01').classList.add('hidden')
        document.querySelector('#menu02').classList.remove('hidden')
        document.querySelector('#menu03').classList.add('hidden')

        document.querySelector('#link01').classList.remove('selected')
        document.querySelector('#link02').classList.add('selected')
        document.querySelector('#link03').classList.remove('selected')
    })

    l3.addEventListener('click', function(){
        document.querySelector('#menu01').classList.add('hidden')
        document.querySelector('#menu02').classList.add('hidden')
        document.querySelector('#menu03').classList.remove('hidden')

        document.querySelector('#link01').classList.remove('selected')
        document.querySelector('#link02').classList.remove('selected')
        document.querySelector('#link03').classList.add('selected')
    })
})()
