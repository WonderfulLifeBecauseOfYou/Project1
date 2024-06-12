a = 100;
a1 = [0 3]; 
set1 = [2.8 0; 0 2.8];
b1 = mvnrnd(a1, set1, a);
a2 = [0 -3]; 
set2 = [2.8 0; 0 2.8]; 
num = mvnrnd(a2, set2, a);

data = [b1; num];
list = [ones(a, 1); -ones(a, 1)];figure;
scatter(b1(:, 1), b1(:, 2), 'r', 'filled');
hold on;
scatter(num(:, 1), num(:, 2), 'b', 'filled');
x = kernel_perceptron(data, list, @rbf_kernel, 100);
[x, y] = meshgrid(linspace(-5, 5, 150), linspace(-7, 7, 150));
z = arrayfun(@(x, y) sum(x .* list .* rbf_kernel(data, [x y])), x, y);
contour(x, y, z, [0 0], 'k');
hold off;
title('Kernel Perceptron Classification with RBF Kernel');

function num = kernel_perceptron(data, labels, kernel_func, max_iter)
    a = size(data, 1);
    num = zeros(a, 1);  
    for iter = 1:max_iter
        for i = 1:a
            prediction = sum(num .* labels .* kernel_func(data, data(i, :)));
            if labels(i) * prediction <= 0
                num(i) = num(i) + 1;
            end
        end
    end
end

function k = rbf_kernel(X, Y)
    sigma = 0.3; 
    distance = bsxfun(@minus, X, Y);
    k = exp(-sum(distance.^2, 2) / (2*sigma^2));
end
