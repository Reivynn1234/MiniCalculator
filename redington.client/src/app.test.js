import { mount } from '@vue/test-utils'
import App from './App.vue'

//
const originalConsoleError = console.error;
const jsDomCssError = 'Error: Could not parse CSS stylesheet';
console.error = (...params) => {
    if (!params.find(p => p.toString().includes(jsDomCssError))) {
        originalConsoleError(...params);
    }
};

// Checks the if button to switch between calculations exists and has the right labels
test('Select Button Exists', async () => {

    const wrapper = mount(App)
    expect(wrapper.findComponent({ name: 'SelectButton' }).exists()).toBe(true);
    const options = wrapper.findAll('.p-button-label');
    expect(options.at(0).text()).toBe("Combined With");
    expect(options.at(1).text()).toBe("Either");
})

// Checks if button can switch between operations
test('Select Button Changes', async () => {

    const wrapper = mount(App)
    const options = wrapper.findAll('.p-button');

    expect(wrapper.find('#combined').exists()).toBe(true)
    expect(wrapper.find('#either').exists()).toBe(false)

    await options.at(1).trigger('click');

    expect(wrapper.find('#combined').exists()).toBe(false)
    expect(wrapper.find('#either').exists()).toBe(true)
})

// Checks to see if input can take in values  
test('Test Inputs valid', async () => {

    const wrapper = mount(App)
    const a = wrapper.find('#a');
    const b = wrapper.find('#b');

    await a.setValue('0.3')

    await b.setValue('0.7')

    expect(a.element.value).toBe('0.3')
    expect(b.element.value).toBe('0.7')

    const button = wrapper.find('#calculate');
    expect(button.classes()).not.toContain('p-disabled')

})

test('Test Inputs invalid', async () => {

    const wrapper = mount(App)
    const a = wrapper.find('#a');
    const b = wrapper.find('#b');

    await a.setValue('-1')
    await b.setValue('0.7')

    const button = wrapper.find('#calculate');
    expect(button.classes()).toContain('p-disabled')

    await a.setValue('0.2')
    await b.setValue('2')

    expect(button.classes()).toContain('p-disabled')

    await a.setValue('-1')
    await b.setValue('2')

    expect(button.classes()).toContain('p-disabled')
})