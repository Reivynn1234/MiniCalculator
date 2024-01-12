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
    expect(options).toHaveLength(2);
    expect(options.at(0).text()).toBe("Combined With");
    expect(options.at(1).text()).toBe("Either");
})

test('Select Button Changes', async () => {

    const wrapper = mount(App)
    const options = wrapper.findAll('.p-button');

    expect(wrapper.find('#combined').exists()).toBe(true)
    expect(wrapper.find('#either').exists()).toBe(false)

    await options.at(1).trigger('click');

    expect(wrapper.find('#combined').exists()).toBe(false)
    expect(wrapper.find('#either').exists()).toBe(true)
})