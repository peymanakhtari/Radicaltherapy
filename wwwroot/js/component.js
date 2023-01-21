const inputElements = [...document.querySelectorAll('input.code-input')]

inputElements.forEach((ele, index) => {
    ele.addEventListener('keydown', (e) => {
        // if the keycode is backspace & the current field is empty
        // focus the input before the current. The event then happens
        // which will clear the input before the current
        if (e.keyCode === 8 && e.target.value === '') inputElements[Math.max(0, index - 1)].focus()
    })
    ele.addEventListener('input', (e) => {
        // take the first character of the input
        // this actually breaks if you input an emoji like 👨‍👩‍👧‍👦....
        // but I'm willing to overlook insane security code practices.
        const [first, ...rest] = e.target.value;
        e.target.value = first;
        if (first === null || first === undefined) {
            e.target.value = '';
        } else {
            e.target.value = first
        }
        const lastInputBox = index === inputElements.length - 1
        const insertedContent = first !== undefined
        if (insertedContent && !lastInputBox) {
            // continue to input the rest of the string
            inputElements[index + 1].focus()
            inputElements[index + 1].value = rest.join('')
            inputElements[index + 1].dispatchEvent(new Event('input'))
        }
    })
})


// mini example on how to pull the data on submit of the form
function onSubmit(e) {
    e.preventDefault()
    const code = [...document.getElementsByTagName('input')]
        .filter(({
            name
        }) => name)
        .map(({
            value
        }) => value)
        .join('')
    console.log(code)
}